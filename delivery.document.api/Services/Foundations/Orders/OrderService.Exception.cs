// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Orders.Exceptions;
using delivery.document.api.Models.Orders;
using MongoDB.Driver;

namespace delivery.document.api.Services.Foundations.Orders
{
    public partial class OrderService
    {
        private delegate ValueTask<Order> ReturnOrderFunction();
        private delegate IQueryable<Order> ReturningQueryableOrdersFunction();

        private async ValueTask<Order> TryCatch(
            ReturnOrderFunction returnOrderFunction)
        {
            try
            {
                return await returnOrderFunction();
            }
            catch (NullOrderException nullOrderException)
            {
                throw CreateAndLogValidationException(nullOrderException);
            }
            catch (InvalidOrderException invalidOrderException)
            {
                throw CreateAndLogValidationException(invalidOrderException);
            }
            catch (NotFoundOrderException notFoundOrderException)
            {
                throw CreateAndLogValidationException(notFoundOrderException);
            }
            catch (MongoWriteException mongoDuplicateKeyException)
            {
                var alreadyExistsOrderException =
                    new AlreadyExistsOrderException(mongoDuplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsOrderException);
            }
            catch (MongoException mongoException)
            {
                var failedOrderServiceException =
                    new FailedOrderServiceException(mongoException);

                throw CreateAndLogDependencyException(failedOrderServiceException);
            }
            catch (Exception exception)
            {
                var failedOrderServiceException =
                    new FailedOrderServiceException(exception);

                throw CreateAndLogServiceException(failedOrderServiceException);
            }
        }

        private IQueryable<Order> TryCatch(
            ReturningQueryableOrdersFunction returningQueryableOrdersFunction)
        {
            try
            {
                return returningQueryableOrdersFunction();
            }
            catch (MongoException mongoException)
            {
                throw CreateAndLogDependencyException(mongoException);
            }
            catch (Exception exception)
            {
                var failedOrderServiceException =
                    new FailedOrderServiceException(exception);

                throw CreateAndLogServiceException(failedOrderServiceException);
            }
        }

        private OrderValidationException CreateAndLogValidationException(Exception exception)
        {
            var orderValidationException = new OrderValidationException(exception, exception.Data);
            this.loggingBroker.LogError(orderValidationException);

            return orderValidationException;
        }

        private OrderDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var orderDependencyException = new OrderDependencyException(exception);
            this.loggingBroker.LogError(orderDependencyException);

            return orderDependencyException;
        }

        private OrderServiceException CreateAndLogServiceException(Exception exception)
        {
            var orderServiceException = new OrderServiceException(exception);
            this.loggingBroker.LogError(orderServiceException);

            return orderServiceException;
        }
    }

}

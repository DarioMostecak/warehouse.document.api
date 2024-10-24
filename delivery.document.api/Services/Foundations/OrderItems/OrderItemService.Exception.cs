// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.OrderItems.Exceptions;
using delivery.document.api.Models.OrderItems;
using MongoDB.Driver;

namespace delivery.document.api.Services.Foundations.OrderItems
{
    public partial class OrderItemService
    {
        private delegate ValueTask<OrderItem> ReturnOrderItemFunction();
        private delegate IQueryable<OrderItem> ReturningQueryableOrderItemsFunction();

        private async ValueTask<OrderItem> TryCatch(
            ReturnOrderItemFunction returnOrderItemFunction)
        {
            try
            {
                return await returnOrderItemFunction();
            }
            catch (NullOrderItemException nullOrderItemException)
            {
                throw CreateAndLogValidationException(nullOrderItemException);
            }
            catch (InvalidOrderItemException invalidOrderItemException)
            {
                throw CreateAndLogValidationException(invalidOrderItemException);
            }
            catch (NotFoundOrderItemException notFoundOrderItemException)
            {
                throw CreateAndLogValidationException(notFoundOrderItemException);
            }
            catch (MongoWriteException mongoDuplicateKeyException)
            {
                var alreadyExistsOrderItemException =
                    new AlreadyExistsOrderItemException(mongoDuplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsOrderItemException);
            }
            catch (MongoException mongoException)
            {
                var failedOrderItemServiceException =
                    new FailedOrderItemServiceException(mongoException);

                throw CreateAndLogDependencyException(failedOrderItemServiceException);
            }
            catch (Exception exception)
            {
                var failedOrderItemServiceException =
                    new FailedOrderItemServiceException(exception);

                throw CreateAndLogServiceException(failedOrderItemServiceException);
            }
        }

        private IQueryable<OrderItem> TryCatch(
            ReturningQueryableOrderItemsFunction returningQueryableOrderItemsFunction)
        {
            try
            {
                return returningQueryableOrderItemsFunction();
            }
            catch (MongoException mongoException)
            {
                throw CreateAndLogDependencyException(mongoException);
            }
            catch (Exception exception)
            {
                var failedOrderItemServiceException =
                    new FailedOrderItemServiceException(exception);

                throw CreateAndLogServiceException(failedOrderItemServiceException);
            }
        }

        private OrderItemValidationException CreateAndLogValidationException(Exception exception)
        {
            var orderItemValidationException = new OrderItemValidationException(exception, exception.Data);
            this.loggingBroker.LogError(orderItemValidationException);

            return orderItemValidationException;
        }

        private OrderItemDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var orderItemDependencyException = new OrderItemDependencyException(exception);
            this.loggingBroker.LogError(orderItemDependencyException);

            return orderItemDependencyException;
        }

        private OrderItemServiceException CreateAndLogServiceException(Exception exception)
        {
            var orderItemServiceException = new OrderItemServiceException(exception);
            this.loggingBroker.LogError(orderItemServiceException);

            return orderItemServiceException;
        }
    }

}

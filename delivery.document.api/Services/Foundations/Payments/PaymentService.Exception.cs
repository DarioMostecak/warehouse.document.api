// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Payments.Exceptions;
using delivery.document.api.Models.Payments;
using MongoDB.Driver;

namespace delivery.document.api.Services.Foundations.Payments
{
    public partial class PaymentService
    {
        private delegate ValueTask<Payment> ReturnPaymentFunction();
        private delegate IQueryable<Payment> ReturningQueryablePaymentsFunction();

        private async ValueTask<Payment> TryCatch(
            ReturnPaymentFunction returnPaymentFunction)
        {
            try
            {
                return await returnPaymentFunction();
            }
            catch (NullPaymentException nullPaymentException)
            {
                throw CreateAndLogValidationException(nullPaymentException);
            }
            catch (InvalidPaymentException invalidPaymentException)
            {
                throw CreateAndLogValidationException(invalidPaymentException);
            }
            catch (NotFoundPaymentException notFoundPaymentException)
            {
                throw CreateAndLogValidationException(notFoundPaymentException);
            }
            catch (MongoWriteException mongoDuplicateKeyException)
            {
                var alreadyExistsPaymentException =
                    new AlreadyExistsPaymentException(mongoDuplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsPaymentException);
            }
            catch (MongoException mongoException)
            {
                var failedPaymentServiceException =
                    new FailedPaymentServiceException(mongoException);

                throw CreateAndLogDependencyException(failedPaymentServiceException);
            }
            catch (Exception exception)
            {
                var failedPaymentServiceException =
                    new FailedPaymentServiceException(exception);

                throw CreateAndLogServiceException(failedPaymentServiceException);
            }
        }

        private IQueryable<Payment> TryCatch(
            ReturningQueryablePaymentsFunction returningQueryablePaymentsFunction)
        {
            try
            {
                return returningQueryablePaymentsFunction();
            }
            catch (MongoException mongoException)
            {
                throw CreateAndLogDependencyException(mongoException);
            }
            catch (Exception exception)
            {
                var failedPaymentServiceException =
                    new FailedPaymentServiceException(exception);

                throw CreateAndLogServiceException(failedPaymentServiceException);
            }
        }

        private PaymentValidationException CreateAndLogValidationException(Exception exception)
        {
            var paymentValidationException = new PaymentValidationException(exception, exception.Data);
            this.loggingBroker.LogError(paymentValidationException);

            return paymentValidationException;
        }

        private PaymentDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var paymentDependencyException = new PaymentDependencyException(exception);
            this.loggingBroker.LogError(paymentDependencyException);

            return paymentDependencyException;
        }

        private PaymentServiceException CreateAndLogServiceException(Exception exception)
        {
            var paymentServiceException = new PaymentServiceException(exception);
            this.loggingBroker.LogError(paymentServiceException);

            return paymentServiceException;
        }
    }

}

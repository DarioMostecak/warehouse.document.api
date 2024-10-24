// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Customers.Exceptions;
using delivery.document.api.Models.Customers;
using MongoDB.Driver;

namespace delivery.document.api.Services.Foundations.Customers
{
    public partial class CustomerService
    {
        private delegate ValueTask<Customer> ReturnCustomerFunction();
        private delegate IQueryable<Customer> ReturningQueryableCustomersFunction();

        private async ValueTask<Customer> TryCatch(
            ReturnCustomerFunction returnCustomerFunction)
        {
            try
            {
                return await returnCustomerFunction();
            }
            catch (NullCustomerException nullCustomerException)
            {
                throw CreateAndLogValidationException(nullCustomerException);
            }
            catch (InvalidCustomerException invalidCustomerException)
            {
                throw CreateAndLogValidationException(invalidCustomerException);
            }
            catch (NotFoundCustomerException notFoundCustomerException)
            {
                throw CreateAndLogValidationException(notFoundCustomerException);
            }
            catch (MongoWriteException mongoDuplicateKeyException)
            {
                var alreadyExistsCustomerException =
                    new AlreadyExistsCustomerException(mongoDuplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsCustomerException);
            }
            catch (MongoException mongoException)
            {
                var failedCustomerServiceException =
                    new FailedCustomerServiceException(mongoException);

                throw CreateAndLogDependencyException(failedCustomerServiceException);
            }
            catch (Exception exception)
            {
                var failedCustomerServiceException =
                    new FailedCustomerServiceException(exception);

                throw CreateAndLogServiceException(failedCustomerServiceException);
            }
        }

        private IQueryable<Customer> TryCatch(
            ReturningQueryableCustomersFunction returningQueryableCustomersFunction)
        {
            try
            {
                return returningQueryableCustomersFunction();
            }
            catch (MongoException mongoException)
            {
                throw CreateAndLogDependencyException(mongoException);
            }
            catch (Exception exception)
            {
                var failedCustomerServiceException =
                    new FailedCustomerServiceException(exception);

                throw CreateAndLogServiceException(failedCustomerServiceException);
            }
        }

        private CustomerValidationException CreateAndLogValidationException(Exception exception)
        {
            var customerValidationException = new CustomerValidationException(exception, exception.Data);
            this.loggingBroker.LogError(customerValidationException);

            return customerValidationException;
        }

        private CustomerDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var customerDependencyException = new CustomerDependencyException(exception);
            this.loggingBroker.LogError(customerDependencyException);

            return customerDependencyException;
        }

        private CustomerServiceException CreateAndLogServiceException(Exception exception)
        {
            var customerServiceException = new CustomerServiceException(exception);
            this.loggingBroker.LogError(customerServiceException);

            return customerServiceException;
        }
    }

}

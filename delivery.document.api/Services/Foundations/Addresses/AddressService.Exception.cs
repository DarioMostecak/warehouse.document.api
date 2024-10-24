// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Addresses.Exceptions;
using delivery.document.api.Models.Addresses;
using MongoDB.Driver;

namespace delivery.document.api.Services.Foundations.Addresses
{
    public partial class AddressService
    {
        private delegate ValueTask<Address> ReturnAddressFunction();
        private delegate IQueryable<Address> ReturningQueryableAddressesFunction();

        private async ValueTask<Address> TryCatch(
            ReturnAddressFunction returnAddressFunction)
        {
            try
            {
                return await returnAddressFunction();
            }
            catch (NullAddressException nullAddressException)
            {
                throw CreateAndLogValidationException(nullAddressException);
            }
            catch (InvalidAddressException invalidAddressException)
            {
                throw CreateAndLogValidationException(invalidAddressException);
            }
            catch (NotFoundAddressException notFoundAddressException)
            {
                throw CreateAndLogValidationException(notFoundAddressException);
            }
            catch (MongoWriteException mongoDuplicateKeyException)
            {
                var alreadyExistsAddressException =
                    new AlreadyExistsAddressException(mongoDuplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsAddressException);
            }
            catch (MongoException mongoException)
            {
                var failedAddressServiceException =
                    new FailedAddressServiceException(mongoException);

                throw CreateAndLogDependencyException(failedAddressServiceException);
            }
            catch (Exception exception)
            {
                var failedAddressServiceException =
                    new FailedAddressServiceException(exception);

                throw CreateAndLogServiceException(failedAddressServiceException);
            }
        }

        private IQueryable<Address> TryCatch(
            ReturningQueryableAddressesFunction returningQueryableAddressesFunction)
        {
            try
            {
                return returningQueryableAddressesFunction();
            }
            catch (MongoException mongoException)
            {
                throw CreateAndLogDependencyException(mongoException);
            }
            catch (Exception exception)
            {
                var failedAddressServiceException =
                    new FailedAddressServiceException(exception);

                throw CreateAndLogServiceException(failedAddressServiceException);
            }
        }

        private AddressValidationException CreateAndLogValidationException(Exception exception)
        {
            var addressValidationException = new AddressValidationException(exception, exception.Data);
            this.loggingBroker.LogError(addressValidationException);

            return addressValidationException;
        }

        private AddressDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var addressDependencyException = new AddressDependencyException(exception);
            this.loggingBroker.LogError(addressDependencyException);

            return addressDependencyException;
        }

        private AddressServiceException CreateAndLogServiceException(Exception exception)
        {
            var addressServiceException = new AddressServiceException(exception);
            this.loggingBroker.LogError(addressServiceException);

            return addressServiceException;
        }
    }
}

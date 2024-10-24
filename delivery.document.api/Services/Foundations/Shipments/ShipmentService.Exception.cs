// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Shipments.Exceptions;
using delivery.document.api.Models.Shipments;
using MongoDB.Driver;

namespace delivery.document.api.Services.Foundations.Shipments
{
    public partial class ShipmentService
    {
        private delegate ValueTask<Shipment> ReturnShipmentFunction();
        private delegate IQueryable<Shipment> ReturningQueryableShipmentsFunction();

        private async ValueTask<Shipment> TryCatch(
            ReturnShipmentFunction returnShipmentFunction)
        {
            try
            {
                return await returnShipmentFunction();
            }
            catch (NullShipmentException nullShipmentException)
            {
                throw CreateAndLogValidationException(nullShipmentException);
            }
            catch (InvalidShipmentException invalidShipmentException)
            {
                throw CreateAndLogValidationException(invalidShipmentException);
            }
            catch (NotFoundShipmentException notFoundShipmentException)
            {
                throw CreateAndLogValidationException(notFoundShipmentException);
            }
            catch (MongoWriteException mongoDuplicateKeyException)
            {
                var alreadyExistsShipmentException =
                    new AlreadyExistsShipmentException(mongoDuplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsShipmentException);
            }
            catch (MongoException mongoException)
            {
                var failedShipmentServiceException =
                    new FailedShipmentServiceException(mongoException);

                throw CreateAndLogDependencyException(failedShipmentServiceException);
            }
            catch (Exception exception)
            {
                var failedShipmentServiceException =
                    new FailedShipmentServiceException(exception);

                throw CreateAndLogServiceException(failedShipmentServiceException);
            }
        }

        private IQueryable<Shipment> TryCatch(
            ReturningQueryableShipmentsFunction returningQueryableShipmentsFunction)
        {
            try
            {
                return returningQueryableShipmentsFunction();
            }
            catch (MongoException mongoException)
            {
                throw CreateAndLogDependencyException(mongoException);
            }
            catch (Exception exception)
            {
                var failedShipmentServiceException =
                    new FailedShipmentServiceException(exception);

                throw CreateAndLogServiceException(failedShipmentServiceException);
            }
        }

        private ShipmentValidationException CreateAndLogValidationException(Exception exception)
        {
            var shipmentValidationException = new ShipmentValidationException(exception, exception.Data);
            this.loggingBroker.LogError(shipmentValidationException);

            return shipmentValidationException;
        }

        private ShipmentDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var shipmentDependencyException = new ShipmentDependencyException(exception);
            this.loggingBroker.LogError(shipmentDependencyException);

            return shipmentDependencyException;
        }

        private ShipmentServiceException CreateAndLogServiceException(Exception exception)
        {
            var shipmentServiceException = new ShipmentServiceException(exception);
            this.loggingBroker.LogError(shipmentServiceException);

            return shipmentServiceException;
        }
    }

}

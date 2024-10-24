// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.DeliveryDocuments.Exceptions;
using delivery.document.api.Models.DeliveryDocuments;
using MongoDB.Driver;

namespace delivery.document.api.Services.Foundations.DeliveryDocuments
{
    public partial class DeliveryDocumentService
    {
        private delegate ValueTask<DeliveryDocument> ReturnDeliveryDocumentFunction();
        private delegate IQueryable<DeliveryDocument> ReturningQueryableDeliveryDocumentsFunction();

        private async ValueTask<DeliveryDocument> TryCatch(
            ReturnDeliveryDocumentFunction returnDeliveryDocumentFunction)
        {
            try
            {
                return await returnDeliveryDocumentFunction();
            }
            catch (NullDeliveryDocumentException nullDeliveryDocumentException)
            {
                throw CreateAndLogValidationException(nullDeliveryDocumentException);
            }
            catch (InvalidDeliveryDocumentException invalidDeliveryDocumentException)
            {
                throw CreateAndLogValidationException(invalidDeliveryDocumentException);
            }
            catch (NotFoundDeliveryDocumentException notFoundDeliveryDocumentException)
            {
                throw CreateAndLogValidationException(notFoundDeliveryDocumentException);
            }
            catch (Exception exception)
            {
                var failedDeliveryDocumentServiceException =
                    new FailedDeliveryDocumentServiceException(exception);

                throw CreateAndLogServiceException(failedDeliveryDocumentServiceException);
            }
        }

        private IQueryable<DeliveryDocument> TryCatch(
            ReturningQueryableDeliveryDocumentsFunction returningQueryableDeliveryDocumentsFunction)
        {
            try
            {
                return returningQueryableDeliveryDocumentsFunction();
            }
            catch (Exception exception)
            {
                var failedDeliveryDocumentServiceException =
                    new FailedDeliveryDocumentServiceException(exception);

                throw CreateAndLogServiceException(failedDeliveryDocumentServiceException);
            }
        }

        private DeliveryDocumentValidationException CreateAndLogValidationException(Exception exception)
        {
            var deliveryDocumentValidationException = new DeliveryDocumentValidationException(exception, exception.Data);
            this.loggingBroker.LogError(deliveryDocumentValidationException);

            return deliveryDocumentValidationException;
        }

        private DeliveryDocumentServiceException CreateAndLogServiceException(Exception exception)
        {
            var deliveryDocumentServiceException = new DeliveryDocumentServiceException(exception);
            this.loggingBroker.LogError(deliveryDocumentServiceException);

            return deliveryDocumentServiceException;
        }
    }


}

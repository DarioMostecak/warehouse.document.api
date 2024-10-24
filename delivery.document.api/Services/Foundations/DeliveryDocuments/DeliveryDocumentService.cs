// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Models.DeliveryDocuments;

namespace delivery.document.api.Services.Foundations.DeliveryDocuments
{
    public partial class DeliveryDocumentService : IDeliveryDocumentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public DeliveryDocumentService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<DeliveryDocument> AddDeliveryDocumentAsync(DeliveryDocument deliveryDocument) =>
        TryCatch(async () =>
        {
            ValidateDeliveryDocumentOnCreate(deliveryDocument);
            return await this.storageBroker.InsertDeliveryDocumentAsync(deliveryDocument);
        });

        public IQueryable<DeliveryDocument> RetrieveAllDeliveryDocuments() =>
        TryCatch(() => this.storageBroker.SelectAllDeliveryDocuments());

        public ValueTask<DeliveryDocument> RetrieveDeliveryDocumentByIdAsync(Guid deliveryDocumentId) =>
        TryCatch(async () =>
        {
            ValidateDeliveryDocumentId(deliveryDocumentId);
            DeliveryDocument maybeDeliveryDocument = 
               await this.storageBroker.SelectDeliveryDocumentByIdAsync(deliveryDocumentId);
            ValidateStorageDeliveryDocument(maybeDeliveryDocument, deliveryDocumentId);

            return maybeDeliveryDocument;
        });

        public ValueTask<DeliveryDocument> ModifyDeliveryDocumentAsync(DeliveryDocument deliveryDocument) =>
        TryCatch(async () =>
        {
            ValidateDeliveryDocumentOnModify(deliveryDocument);

            DeliveryDocument maybeDeliveryDocument = 
               await this.storageBroker.SelectDeliveryDocumentByIdAsync(deliveryDocument.DeliveryDocumentID);

            ValidateStorageDeliveryDocument(maybeDeliveryDocument, deliveryDocument.DeliveryDocumentID);
            ValidateAgainstStorageDeliveryDocumentOnModify(
                inputDeliveryDocument: deliveryDocument,
                storageDeliveryDocument: maybeDeliveryDocument);

            var updatedDeliveryDocument = await this.storageBroker.UpdateDeliveryDocumentAsync(deliveryDocument);
            return updatedDeliveryDocument;
        });

        public ValueTask<DeliveryDocument> RemoveDeliveryDocumentByIdAsync(Guid deliveryDocumentId) =>
        TryCatch(async () =>
        {
            ValidateDeliveryDocumentId(deliveryDocumentId);
            DeliveryDocument maybeDeliveryDocument =
               await this.storageBroker.SelectDeliveryDocumentByIdAsync(deliveryDocumentId);  
            ValidateStorageDeliveryDocument(maybeDeliveryDocument, deliveryDocumentId);

            var deletedDeliveryDocument = await this.storageBroker.DeleteDeliveryDocumentAsync(maybeDeliveryDocument);
            return deletedDeliveryDocument;
        });
    }


}

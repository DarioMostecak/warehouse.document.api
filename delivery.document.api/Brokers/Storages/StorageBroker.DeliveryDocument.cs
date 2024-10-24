// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.DeliveryDocuments;
using MongoDB.Driver;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        private IMongoCollection<DeliveryDocument> deliveryDocumentCollection;

        public async ValueTask<DeliveryDocument> InsertDeliveryDocumentAsync(DeliveryDocument deliveryDocument)
        {
            this.deliveryDocumentCollection =
                this.db.GetCollection<DeliveryDocument>(GetCollectionName<DeliveryDocument>());

            await this.deliveryDocumentCollection.InsertOneAsync(deliveryDocument);
            return deliveryDocument;
        }

        public IQueryable<DeliveryDocument> SelectAllDeliveryDocuments()
        {
            this.deliveryDocumentCollection =
                this.db.GetCollection<DeliveryDocument>(GetCollectionName<DeliveryDocument>());

            return this.deliveryDocumentCollection.AsQueryable();
        }

        public async ValueTask<DeliveryDocument> SelectDeliveryDocumentByIdAsync(Guid deliveryDocumentId)
        {
            this.deliveryDocumentCollection =
                this.db.GetCollection<DeliveryDocument>(GetCollectionName<DeliveryDocument>());

            var deliveryDocument = await this.deliveryDocumentCollection
                .Find(doc => doc.DeliveryDocumentID == deliveryDocumentId)
                .FirstOrDefaultAsync();

            return deliveryDocument;
        }

        public async ValueTask<DeliveryDocument> UpdateDeliveryDocumentAsync(DeliveryDocument deliveryDocument)
        {
            this.deliveryDocumentCollection =
                this.db.GetCollection<DeliveryDocument>(GetCollectionName<DeliveryDocument>());

            await this.deliveryDocumentCollection
                .ReplaceOneAsync(doc => doc.DeliveryDocumentID == deliveryDocument.DeliveryDocumentID, deliveryDocument);

            return deliveryDocument;
        }

        public async ValueTask<DeliveryDocument> DeleteDeliveryDocumentAsync(DeliveryDocument deliveryDocument)
        {
            this.deliveryDocumentCollection =
                this.db.GetCollection<DeliveryDocument>(GetCollectionName<DeliveryDocument>());

            await this.deliveryDocumentCollection
                .DeleteOneAsync(doc => doc.DeliveryDocumentID == deliveryDocument.DeliveryDocumentID);

            return deliveryDocument;
        }
    }
}

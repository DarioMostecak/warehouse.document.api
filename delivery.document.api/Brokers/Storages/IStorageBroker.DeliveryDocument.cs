// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.DeliveryDocuments;

namespace delivery.document.api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<DeliveryDocument> InsertDeliveryDocumentAsync(DeliveryDocument deliveryDocument);
        IQueryable<DeliveryDocument> SelectAllDeliveryDocuments();
        ValueTask<DeliveryDocument> SelectDeliveryDocumentByIdAsync(Guid deliveryDocumentId);
        ValueTask<DeliveryDocument> UpdateDeliveryDocumentAsync(DeliveryDocument deliveryDocument);
        ValueTask<DeliveryDocument> DeleteDeliveryDocumentAsync(DeliveryDocument deliveryDocument);
    }
}

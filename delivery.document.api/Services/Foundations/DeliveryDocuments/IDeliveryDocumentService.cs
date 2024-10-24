// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.DeliveryDocuments;

namespace delivery.document.api.Services.Foundations.DeliveryDocuments
{
    public interface IDeliveryDocumentService
    {
        ValueTask<DeliveryDocument> AddDeliveryDocumentAsync(DeliveryDocument deliveryDocument);
        IQueryable<DeliveryDocument> RetrieveAllDeliveryDocuments();
        ValueTask<DeliveryDocument> RetrieveDeliveryDocumentByIdAsync(Guid deliveryDocumentId);
        ValueTask<DeliveryDocument> ModifyDeliveryDocumentAsync(DeliveryDocument deliveryDocument);
        ValueTask<DeliveryDocument> RemoveDeliveryDocumentByIdAsync(Guid deliveryDocumentId);
    }
}
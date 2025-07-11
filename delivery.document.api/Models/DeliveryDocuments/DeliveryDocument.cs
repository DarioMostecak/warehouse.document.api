// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Attributes;
using delivery.document.api.Models.Shipments;

namespace delivery.document.api.Models.DeliveryDocuments
{
    [BsonCollection("delivery_document")]
    public class DeliveryDocument
    {
        public Guid DeliveryDocumentID { get; set; }
        public Guid ShipmentID { get; set; }
        public string DocumentType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Shipment Shipment { get; set; }
    }
}

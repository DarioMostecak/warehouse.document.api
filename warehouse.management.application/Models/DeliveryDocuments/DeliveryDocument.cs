// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.Shipments;

namespace warehouse.management.application.Models.DeliveryDocuments
{
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

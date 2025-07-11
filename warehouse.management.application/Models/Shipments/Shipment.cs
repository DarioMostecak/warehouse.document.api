// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.DeliveryDocuments;
using warehouse.management.application.Models.Orders;

namespace warehouse.management.application.Models.Shipments
{
    public class Shipment
    {
        public Guid ShipmentID { get; set; }
        public Guid OrderID { get; set; }

        public DateTime ShipmentDate { get; set; }
        public string Carrier { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Order Order { get; set; }
        public ICollection<DeliveryDocument> DeliveryDocuments { get; set; }
    }
}

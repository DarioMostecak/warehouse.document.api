using delivery.document.api.Attributes;
using delivery.document.api.Models.DeliveryDocuments;
using delivery.document.api.Models.Orders;

namespace delivery.document.api.Models.Shipments
{
    [BsonCollection("shipment")]
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

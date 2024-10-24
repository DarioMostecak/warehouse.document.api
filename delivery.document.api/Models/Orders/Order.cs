// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Attributes;
using delivery.document.api.Models.Addresses;
using delivery.document.api.Models.Customers;
using delivery.document.api.Models.OrderItems;
using delivery.document.api.Models.Shipments;

namespace delivery.document.api.Models.Orders
{
    [BsonCollection("order")]
    public class Order
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public Guid AddressID { get; set; }

        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
        public Address ShippingAddress { get; set; }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.Addresses;
using warehouse.management.application.Models.Customers;
using warehouse.management.application.Models.OrderItems;
using warehouse.management.application.Models.Shipments;

namespace warehouse.management.application.Models.Orders
{
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

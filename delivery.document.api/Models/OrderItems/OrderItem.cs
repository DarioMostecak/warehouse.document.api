// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Attributes;
using delivery.document.api.Models.Orders;
using delivery.document.api.Models.Products;

namespace delivery.document.api.Models.OrderItems
{
    [BsonCollection("order_item")]
    public class OrderItem
    {
        public Guid OrderItemID { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}

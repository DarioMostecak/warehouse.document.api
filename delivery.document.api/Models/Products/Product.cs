// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Attributes;
using delivery.document.api.Models.OrderItems;

namespace delivery.document.api.Models.Products
{
    [BsonCollection("product")]
    public class Product
    {
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}

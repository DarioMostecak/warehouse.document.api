// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Attributes;
using delivery.document.api.Models.Orders;

namespace delivery.document.api.Models.Invoices
{
    [BsonCollection("Invoice")]
    public class Invoice
    {
        public Guid InvoiceID { get; set; }
        public Guid OrderID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Order Order { get; set; }
    }
}

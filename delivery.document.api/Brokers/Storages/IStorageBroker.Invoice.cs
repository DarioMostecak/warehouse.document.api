// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Invoices;

namespace delivery.document.api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Invoice> InsertInvoiceAsync(Invoice invoice);
        IQueryable<Invoice> SelectAllInvoices();
        ValueTask<Invoice> SelectInvoiceByIdAsync(Guid invoiceId);
        ValueTask<Invoice> UpdateInvoiceAsync(Invoice invoice);
        ValueTask<Invoice> DeleteInvoiceAsync(Invoice invoice);
    }
}

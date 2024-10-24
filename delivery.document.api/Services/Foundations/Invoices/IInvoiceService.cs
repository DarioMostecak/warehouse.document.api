// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Invoices;

namespace delivery.document.api.Services.Foundations.Invoices
{
    public interface IInvoiceService
    {
        ValueTask<Invoice> AddInvoiceAsync(Invoice invoice);
        IQueryable<Invoice> RetrieveAllInvoices();
        ValueTask<Invoice> RetrieveInvoiceByIdAsync(Guid invoiceId);
        ValueTask<Invoice> ModifyInvoiceAsync(Invoice invoice);
        ValueTask<Invoice> RemoveInvoiceByIdAsync(Guid invoiceId);
    }
}
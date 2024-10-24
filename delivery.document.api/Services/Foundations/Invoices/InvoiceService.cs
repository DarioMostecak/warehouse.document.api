// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Models.Invoices;

namespace delivery.document.api.Services.Foundations.Invoices
{
    public partial class InvoiceService : IInvoiceService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public InvoiceService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Invoice> AddInvoiceAsync(Invoice invoice) =>
        TryCatch(async () =>
        {
            ValidateInvoiceOnCreate(invoice);

            return await this.storageBroker.InsertInvoiceAsync(invoice);
        });

        public IQueryable<Invoice> RetrieveAllInvoices() =>
        TryCatch(() => this.storageBroker.SelectAllInvoices());

        public ValueTask<Invoice> RetrieveInvoiceByIdAsync(Guid invoiceId) =>
        TryCatch(async () =>
        {
            ValidateInvoiceIdIsNull(invoiceId);
            Invoice maybeInvoice = await this.storageBroker.SelectInvoiceByIdAsync(invoiceId);
            ValidateStorageInvoice(maybeInvoice, invoiceId);

            return maybeInvoice;
        });

        public ValueTask<Invoice> ModifyInvoiceAsync(Invoice invoice) =>
        TryCatch(async () =>
        {
            ValidateInvoiceOnModify(invoice);
            Invoice maybeInvoice = await this.storageBroker.SelectInvoiceByIdAsync(invoice.InvoiceID);

            ValidateStorageInvoice(maybeInvoice, invoice.InvoiceID);
            ValidateAgainstStorageInvoiceOnModify(inputInvoice: invoice, storageInvoice: maybeInvoice);

            var updatedInvoice = await this.storageBroker.UpdateInvoiceAsync(invoice);

            return updatedInvoice;
        });

        public ValueTask<Invoice> RemoveInvoiceByIdAsync(Guid invoiceId) =>
        TryCatch(async () =>
        {
            ValidateInvoiceIdIsNull(invoiceId);
            Invoice maybeInvoice = await this.storageBroker.SelectInvoiceByIdAsync(invoiceId);
            ValidateStorageInvoice(maybeInvoice, invoiceId);

            var deletedInvoice = await this.storageBroker.DeleteInvoiceAsync(maybeInvoice);

            return deletedInvoice;
        });
    }

}

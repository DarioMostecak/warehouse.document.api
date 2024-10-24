// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Invoices;
using MongoDB.Driver;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        private IMongoCollection<Invoice> invoiceCollection;

        public async ValueTask<Invoice> InsertInvoiceAsync(Invoice invoice)
        {
            this.invoiceCollection =
                this.db.GetCollection<Invoice>(GetCollectionName<Invoice>());

            await this.invoiceCollection.InsertOneAsync(invoice);
            return invoice;
        }

        public IQueryable<Invoice> SelectAllInvoices()
        {
            this.invoiceCollection =
                this.db.GetCollection<Invoice>(GetCollectionName<Invoice>());

            return this.invoiceCollection.AsQueryable();
        }

        public async ValueTask<Invoice> SelectInvoiceByIdAsync(Guid invoiceId)
        {
            this.invoiceCollection =
                this.db.GetCollection<Invoice>(GetCollectionName<Invoice>());

            var invoice = await this.invoiceCollection
                .Find(inv => inv.InvoiceID == invoiceId)
                .FirstOrDefaultAsync();

            return invoice;
        }

        public async ValueTask<Invoice> UpdateInvoiceAsync(Invoice invoice)
        {
            this.invoiceCollection =
                this.db.GetCollection<Invoice>(GetCollectionName<Invoice>());

            await this.invoiceCollection
                .ReplaceOneAsync(inv => inv.InvoiceID == invoice.InvoiceID, invoice);

            return invoice;
        }

        public async ValueTask<Invoice> DeleteInvoiceAsync(Invoice invoice)
        {
            this.invoiceCollection =
                this.db.GetCollection<Invoice>(GetCollectionName<Invoice>());

            await this.invoiceCollection
                .DeleteOneAsync(inv => inv.InvoiceID == invoice.InvoiceID);

            return invoice;
        }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Payments;
using MongoDB.Driver;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        private IMongoCollection<Payment> paymentCollection;

        public async ValueTask<Payment> InsertPaymentAsync(Payment payment)
        {
            this.paymentCollection =
                this.db.GetCollection<Payment>(GetCollectionName<Payment>());

            await this.paymentCollection.InsertOneAsync(payment);
            return payment;
        }

        public IQueryable<Payment> SelectAllPayments()
        {
            this.paymentCollection =
                this.db.GetCollection<Payment>(GetCollectionName<Payment>());

            return this.paymentCollection.AsQueryable();
        }

        public async ValueTask<Payment> SelectPaymentByIdAsync(Guid paymentId)
        {
            this.paymentCollection =
                this.db.GetCollection<Payment>(GetCollectionName<Payment>());

            var payment = await this.paymentCollection
                .Find(pay => pay.PaymentID == paymentId)
                .FirstOrDefaultAsync();

            return payment;
        }

        public async ValueTask<Payment> UpdatePaymentAsync(Payment payment)
        {
            this.paymentCollection =
                this.db.GetCollection<Payment>(GetCollectionName<Payment>());

            await this.paymentCollection
                .ReplaceOneAsync(pay => pay.PaymentID == payment.PaymentID, payment);

            return payment;
        }

        public async ValueTask<Payment> DeletePaymentAsync(Payment payment)
        {
            this.paymentCollection =
                this.db.GetCollection<Payment>(GetCollectionName<Payment>());

            await this.paymentCollection
                .DeleteOneAsync(pay => pay.PaymentID == payment.PaymentID);

            return payment;
        }
    }
}

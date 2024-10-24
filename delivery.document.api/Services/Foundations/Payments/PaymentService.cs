// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Models.Payments;

namespace delivery.document.api.Services.Foundations.Payments
{
    public partial class PaymentService : IPaymentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public PaymentService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Payment> AddPaymentAsync(Payment payment) =>
        TryCatch(async () =>
        {
            ValidatePaymentOnCreate(payment);
            return await this.storageBroker.InsertPaymentAsync(payment);
        });

        public IQueryable<Payment> RetrieveAllPayments() =>
        TryCatch(() => this.storageBroker.SelectAllPayments());

        public ValueTask<Payment> RetrievePaymentByIdAsync(Guid paymentId) =>
        TryCatch(async () =>
        {
            ValidatePaymentIdIsNull(paymentId);
            Payment maybePayment = await this.storageBroker.SelectPaymentByIdAsync(paymentId);
            ValidateStoragePayment(maybePayment, paymentId);

            return maybePayment;
        });

        public ValueTask<Payment> ModifyPaymentAsync(Payment payment) =>
        TryCatch(async () =>
        {
            ValidatePaymentOnModify(payment);
            Payment maybePayment = await this.storageBroker.SelectPaymentByIdAsync(payment.PaymentID);

            ValidateStoragePayment(maybePayment, payment.PaymentID);
            ValidateAgainstStoragePaymentOnModify(inputPayment: payment, storagePayment: maybePayment);

            var updatedPayment = await this.storageBroker.UpdatePaymentAsync(payment);

            return updatedPayment;
        });

        public ValueTask<Payment> RemovePaymentByIdAsync(Guid paymentId) =>
        TryCatch(async () =>
        {
            ValidatePaymentIdIsNull(paymentId);
            Payment maybePayment = await this.storageBroker.SelectPaymentByIdAsync(paymentId);
            ValidateStoragePayment(maybePayment, paymentId);

            var deletedPayment = await this.storageBroker.DeletePaymentAsync(maybePayment);

            return deletedPayment;
        });
    }

}

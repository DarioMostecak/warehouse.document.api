// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Payments;

namespace delivery.document.api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Payment> InsertPaymentAsync(Payment payment);
        IQueryable<Payment> SelectAllPayments();
        ValueTask<Payment> SelectPaymentByIdAsync(Guid paymentId);
        ValueTask<Payment> UpdatePaymentAsync(Payment payment);
        ValueTask<Payment> DeletePaymentAsync(Payment payment);
    }
}

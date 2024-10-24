// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Payments;

namespace delivery.document.api.Services.Foundations.Payments
{
    public interface IPaymentService
    {
        ValueTask<Payment> AddPaymentAsync(Payment payment);
        IQueryable<Payment> RetrieveAllPayments();
        ValueTask<Payment> RetrievePaymentByIdAsync(Guid paymentId);
        ValueTask<Payment> ModifyPaymentAsync(Payment payment);
        ValueTask<Payment> RemovePaymentByIdAsync(Guid paymentId);
    }
}
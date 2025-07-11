// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Payments.Exceptions
{
    public class PaymentServiceException : ExceptionModel
    {
        public PaymentServiceException(Exception innerException)
        : base(message: "Payment service error, please contact support.", innerException)
        { }
    }
}

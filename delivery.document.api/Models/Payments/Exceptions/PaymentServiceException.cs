// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Payments.Exceptions
{
    public class PaymentServiceException : ExceptionModel
    {
        public PaymentServiceException(Exception innerException)
        : base(message: "Payment service error, please contact support.", innerException)
        { }
    }
}

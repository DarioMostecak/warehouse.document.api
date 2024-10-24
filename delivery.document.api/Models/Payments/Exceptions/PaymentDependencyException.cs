// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Payments.Exceptions
{
    public class PaymentDependencyException : ExceptionModel
    {
        public PaymentDependencyException(Exception innerException)
          : base(message: "Payment dependency error occurred, please contact support.", innerException)
        { }
    }
}

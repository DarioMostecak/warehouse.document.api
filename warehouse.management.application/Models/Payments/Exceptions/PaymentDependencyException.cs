// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Payments.Exceptions
{
    public class PaymentDependencyException : ExceptionModel
    {
        public PaymentDependencyException(Exception innerException)
          : base(message: "Payment dependency error occurred, please contact support.", innerException)
        { }
    }
}

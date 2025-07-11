// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Payments.Exceptions
{
    public class FailedPaymentDependencyException : ExceptionModel
    {
        public FailedPaymentDependencyException(Exception innerException)
          : base(message: "Failed dependency exception. Contact support.") { }
    }
}

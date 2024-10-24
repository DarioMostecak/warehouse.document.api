// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Payments.Exceptions
{
    public class FailedPaymentDependencyException : ExceptionModel
    {
        public FailedPaymentDependencyException(Exception innerException)
          : base(message: "Failed dependency exception. Contact support.") { }
    }
}

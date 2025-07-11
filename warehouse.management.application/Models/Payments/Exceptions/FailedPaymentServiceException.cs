// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Payments.Exceptions
{
    public class FailedPaymentServiceException : ExceptionModel
    {
        public FailedPaymentServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

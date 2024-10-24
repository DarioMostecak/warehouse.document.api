// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Payments.Exceptions
{
    public class FailedPaymentServiceException : ExceptionModel
    {
        public FailedPaymentServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

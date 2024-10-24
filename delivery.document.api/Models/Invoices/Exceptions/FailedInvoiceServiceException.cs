// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Invoices.Exceptions
{
    public class FailedInvoiceServiceException : ExceptionModel
    {
        public FailedInvoiceServiceException(Exception innerException)
            : base(message: "Failed service exception. Contact support.") { }
    }
}

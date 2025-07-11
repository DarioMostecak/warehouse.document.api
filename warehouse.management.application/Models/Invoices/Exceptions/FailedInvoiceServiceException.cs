// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Invoices.Exceptions
{
    public class FailedInvoiceServiceException : ExceptionModel
    {
        public FailedInvoiceServiceException(Exception innerException)
            : base(message: "Failed service exception. Contact support.") { }
    }
}

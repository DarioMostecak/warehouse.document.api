// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Invoices.Exceptions
{
    public class FailedInvoiceDependencyException : ExceptionModel
    {
        public FailedInvoiceDependencyException(Exception innerException)
           : base(message: "Failed dependency exception. Contact support.") { }
    }
}

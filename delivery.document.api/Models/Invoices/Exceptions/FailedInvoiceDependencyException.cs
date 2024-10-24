// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Invoices.Exceptions
{
    public class FailedInvoiceDependencyException : ExceptionModel
    {
        public FailedInvoiceDependencyException(Exception innerException)
           : base(message: "Failed dependency exception. Contact support.") { }
    }
}

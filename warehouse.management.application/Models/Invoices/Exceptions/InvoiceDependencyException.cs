// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Invoices.Exceptions
{
    public class InvoiceDependencyException : ExceptionModel
    {
        public InvoiceDependencyException(Exception innerException)
           : base(message: "Invoice dependency error occurred, please contact support.", innerException)
        { }
    }
}

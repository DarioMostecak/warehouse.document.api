// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Invoices.Exceptions
{
    public class InvoiceDependencyException : ExceptionModel
    {
        public InvoiceDependencyException(Exception innerException)
           : base(message: "Invoice dependency error occurred, please contact support.", innerException)
        { }
    }
}

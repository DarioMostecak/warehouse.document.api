// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Invoices.Exceptions
{
    public class InvoiceServiceException : ExceptionModel
    {
        public InvoiceServiceException(Exception innerException)
         : base(message: "Invoice service error, please contact support.", innerException)
        { }
    }
}

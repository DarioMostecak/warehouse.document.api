// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Invoices.Exceptions
{
    public class AlreadyExistsInvoiceException : ExceptionModel
    {
        public AlreadyExistsInvoiceException(Exception innerException)
            : base(message: "Invoice with same id already exists.", innerException) { }
    }
}

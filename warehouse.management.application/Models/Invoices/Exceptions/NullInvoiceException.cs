// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Invoices.Exceptions
{
    public class NullInvoiceException : ExceptionModel
    {
        public NullInvoiceException()
          : base(message: "Invoice is null.") { }
    }
}

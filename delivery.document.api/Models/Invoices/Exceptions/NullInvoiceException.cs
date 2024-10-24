// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Invoices.Exceptions
{
    public class NullInvoiceException : ExceptionModel
    {
        public NullInvoiceException()
          : base(message: "Invoice is null.") { }
    }
}

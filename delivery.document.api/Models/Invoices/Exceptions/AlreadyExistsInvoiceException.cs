// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Invoices.Exceptions
{
    public class AlreadyExistsInvoiceException : ExceptionModel
    {
        public AlreadyExistsInvoiceException(Exception innerException)
            : base(message: "Invoice with same id already exists.", innerException) { }
    }
}

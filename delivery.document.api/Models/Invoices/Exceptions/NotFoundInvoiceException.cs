// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Invoices.Exceptions
{
    public class NotFoundInvoiceException : ExceptionModel
    {
        public NotFoundInvoiceException(Guid id)
          : base(message: $"Invoice with id:{id} couldn't be found.") { }
    }
}

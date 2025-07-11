// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Invoices.Exceptions
{
    public class NotFoundInvoiceException : ExceptionModel
    {
        public NotFoundInvoiceException(Guid id)
          : base(message: $"Invoice with id:{id} couldn't be found.") { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using System.Collections;
using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Invoices.Exceptions
{
    public class InvoiceValidationException : ExceptionModel
    {
        public InvoiceValidationException(Exception innerException, IDictionary data)
           : base(message: innerException.Message, innerException, data: data)
        { }
    }
}

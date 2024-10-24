// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;
using System.Collections;

namespace delivery.document.api.Models.Invoices.Exceptions
{
    public class InvoiceValidationException : ExceptionModel
    {
        public InvoiceValidationException(Exception innerException, IDictionary data)
           : base(message: innerException.Message, innerException, data: data)
        { }
    }
}

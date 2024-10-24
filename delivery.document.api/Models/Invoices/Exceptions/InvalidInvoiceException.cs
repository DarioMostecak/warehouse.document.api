// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Invoices.Exceptions
{
    public class InvalidInvoiceException : ExceptionModel
    {
        public InvalidInvoiceException()
           : base(message: "Invalid invoice. Please fix errors and try again.") { }

        public InvalidInvoiceException(string parameterName, object parameterValue)
           : base(message: $"Invalid invoice, " +
                 $"parameter name: {parameterName}," +
                 $"parameter value: {parameterValue}")
        { }
    }
}

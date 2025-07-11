// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Invoices.Exceptions
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

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Payments.Exceptions
{
    public class InvalidPaymentException : ExceptionModel
    {
        public InvalidPaymentException()
          : base(message: "Invalid payment. Please fix errors and try again.") { }

        public InvalidPaymentException(string parameterName, object parameterValue)
           : base(message: $"Invalid payment, " +
                 $"parameter name: {parameterName}," +
                 $"parameter value: {parameterValue}")
        { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Payments.Exceptions
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

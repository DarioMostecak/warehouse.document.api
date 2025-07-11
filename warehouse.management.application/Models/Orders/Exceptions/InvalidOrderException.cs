// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Orders.Exceptions
{
    public class InvalidOrderException : ExceptionModel
    {
        public InvalidOrderException()
          : base(message: "Invalid order. Please fix errors and try again.") { }

        public InvalidOrderException(string parameterName, object parameterValue)
           : base(message: $"Invalid order, " +
                 $"parameter name: {parameterName}," +
                 $"parameter value: {parameterValue}")
        { }
    }
}

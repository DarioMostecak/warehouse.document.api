// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Orders.Exceptions
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

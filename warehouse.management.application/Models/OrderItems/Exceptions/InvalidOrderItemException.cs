// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.OrderItems.Exceptions
{
    public class InvalidOrderItemException : ExceptionModel
    {
        public InvalidOrderItemException()
           : base(message: "Invalid order_item. Please fix errors and try again.") { }

        public InvalidOrderItemException(string parameterName, object parameterValue)
           : base(message: $"Invalid order_item, " +
                 $"parameter name: {parameterName}," +
                 $"parameter value: {parameterValue}")
        { }
    }
}

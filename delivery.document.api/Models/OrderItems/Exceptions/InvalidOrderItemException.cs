// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.OrderItems.Exceptions
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

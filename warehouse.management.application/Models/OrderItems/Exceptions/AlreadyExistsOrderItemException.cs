// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.OrderItems.Exceptions
{
    public class AlreadyExistsOrderItemException : ExceptionModel
    {
        public AlreadyExistsOrderItemException(Exception innerException)
            : base(message: "Order_item with same id already exists.", innerException) { }
    }
}

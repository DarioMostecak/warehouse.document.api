// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.OrderItems.Exceptions
{
    public class NullOrderItemException : ExceptionModel
    {
        public NullOrderItemException()
          : base(message: "Order_item is null.") { }
    }
}

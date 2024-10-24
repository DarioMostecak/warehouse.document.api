// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.OrderItems.Exceptions
{
    public class NullOrderItemException : ExceptionModel
    {
        public NullOrderItemException()
          : base(message: "Order_item is null.") { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.OrderItems.Exceptions
{
    public class AlreadyExistsOrderItemException : ExceptionModel
    {
        public AlreadyExistsOrderItemException(Exception innerException)
            : base(message: "Order_item with same id already exists.", innerException) { }
    }
}

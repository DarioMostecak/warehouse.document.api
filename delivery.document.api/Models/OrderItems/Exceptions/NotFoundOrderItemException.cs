// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.OrderItems.Exceptions
{
    public class NotFoundOrderItemException : ExceptionModel
    {
        public NotFoundOrderItemException(Guid id)
        : base(message: $"Order_item with id:{id} couldn't be found.")
        { }
    }
}

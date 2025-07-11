// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.OrderItems.Exceptions
{
    public class NotFoundOrderItemException : ExceptionModel
    {
        public NotFoundOrderItemException(Guid id)
        : base(message: $"Order_item with id:{id} couldn't be found.")
        { }
    }
}

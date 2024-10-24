// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.OrderItems.Exceptions
{
    public class OrderItemDependencyException : ExceptionModel
    {
        public OrderItemDependencyException(Exception innerException)
           : base(message: "Order_Item dependency error occurred, please contact support.", innerException)
        { }
    }
}

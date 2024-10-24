// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.OrderItems.Exceptions
{
    public class OrderItemServiceException : ExceptionModel
    {
        public OrderItemServiceException(Exception innerException)
         : base(message: "Order_item service error, please contact support.", innerException)
        { }
    }
}

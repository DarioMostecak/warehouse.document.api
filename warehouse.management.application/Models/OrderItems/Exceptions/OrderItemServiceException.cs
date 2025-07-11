// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.OrderItems.Exceptions
{
    public class OrderItemServiceException : ExceptionModel
    {
        public OrderItemServiceException(Exception innerException)
         : base(message: "Order_item service error, please contact support.", innerException)
        { }
    }
}

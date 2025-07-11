// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Orders.Exceptions
{
    public class OrderServiceException : ExceptionModel
    {
        public OrderServiceException(Exception innerException)
       : base(message: "Order service error, please contact support.", innerException)
        { }
    }
}

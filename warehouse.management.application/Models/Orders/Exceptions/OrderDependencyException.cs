// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Orders.Exceptions
{
    public class OrderDependencyException : ExceptionModel
    {
        public OrderDependencyException(Exception innerException)
          : base(message: "Order dependency error occurred, please contact support.", innerException)
        { }
    }
}

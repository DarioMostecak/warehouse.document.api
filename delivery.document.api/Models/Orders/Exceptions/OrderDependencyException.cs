// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Orders.Exceptions
{
    public class OrderDependencyException : ExceptionModel
    {
        public OrderDependencyException(Exception innerException)
          : base(message: "Order dependency error occurred, please contact support.", innerException)
        { }
    }
}

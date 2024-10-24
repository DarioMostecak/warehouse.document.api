// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Orders.Exceptions
{
    public class OrderServiceException : ExceptionModel
    {
        public OrderServiceException(Exception innerException)
       : base(message: "Order service error, please contact support.", innerException)
        { }
    }
}

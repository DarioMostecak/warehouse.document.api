// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.OrderItems.Exceptions
{
    public class FailedOrderItemDependencyException : ExceptionModel
    {

        public FailedOrderItemDependencyException(Exception innerException)
           : base(message: "Failed dependency exception. Contact support.") { }
    }
}

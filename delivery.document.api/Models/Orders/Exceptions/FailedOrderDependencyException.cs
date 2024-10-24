// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Orders.Exceptions
{
    public class FailedOrderDependencyException : ExceptionModel
    {
        public FailedOrderDependencyException(Exception innerException)
          : base(message: "Failed dependency exception. Contact support.") { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Orders.Exceptions
{
    public class FailedOrderDependencyException : ExceptionModel
    {
        public FailedOrderDependencyException(Exception innerException)
          : base(message: "Failed dependency exception. Contact support.") { }
    }
}

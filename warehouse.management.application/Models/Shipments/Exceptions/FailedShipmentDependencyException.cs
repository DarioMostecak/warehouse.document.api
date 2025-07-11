// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Shipments.Exceptions
{
    public class FailedShipmentDependencyException : ExceptionModel
    {
        public FailedShipmentDependencyException(Exception innerException)
          : base(message: "Failed dependency exception. Contact support.") { }
    }
}

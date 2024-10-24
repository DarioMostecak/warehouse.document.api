// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Shipments.Exceptions
{
    public class FailedShipmentDependencyException : ExceptionModel
    {
        public FailedShipmentDependencyException(Exception innerException)
          : base(message: "Failed dependency exception. Contact support.") { }
    }
}

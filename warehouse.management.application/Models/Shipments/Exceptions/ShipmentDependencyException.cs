// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Shipments.Exceptions
{
    public class ShipmentDependencyException : ExceptionModel
    {
        public ShipmentDependencyException(Exception innerException)
          : base(message: "Shipment dependency error occurred, please contact support.", innerException)
        { }
    }
}

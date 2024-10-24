// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Shipments.Exceptions
{
    public class ShipmentDependencyException : ExceptionModel
    {
        public ShipmentDependencyException(Exception innerException)
          : base(message: "Shipment dependency error occurred, please contact support.", innerException)
        { }
    }
}

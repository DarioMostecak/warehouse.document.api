// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Shipments.Exceptions
{
    public class ShipmentServiceException : ExceptionModel
    {
        public ShipmentServiceException(Exception innerException)
        : base(message: "Shipment service error, please contact support.", innerException)
        { }
    }
}

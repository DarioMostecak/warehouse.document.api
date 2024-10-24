// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Shipments.Exceptions
{
    public class ShipmentServiceException : ExceptionModel
    {
        public ShipmentServiceException(Exception innerException)
        : base(message: "Shipment service error, please contact support.", innerException)
        { }
    }
}

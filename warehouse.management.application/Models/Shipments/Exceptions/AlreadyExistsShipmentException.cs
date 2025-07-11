// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Shipments.Exceptions
{
    public class AlreadyExistsShipmentException : ExceptionModel
    {
        public AlreadyExistsShipmentException(Exception innerException)
           : base(message: "Shipment with same id already exists.", innerException) { }
    }
}

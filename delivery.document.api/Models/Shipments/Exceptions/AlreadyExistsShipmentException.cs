// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Shipments.Exceptions
{
    public class AlreadyExistsShipmentException : ExceptionModel
    {
        public AlreadyExistsShipmentException(Exception innerException)
           : base(message: "Shipment with same id already exists.", innerException) { }
    }
}

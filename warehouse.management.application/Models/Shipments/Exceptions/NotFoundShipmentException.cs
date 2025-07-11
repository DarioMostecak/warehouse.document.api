// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Shipments.Exceptions
{
    public class NotFoundShipmentException : ExceptionModel
    {
        public NotFoundShipmentException(Guid id)
        : base(message: $"Shipment with id:{id} couldn't be found.") { }
    }
}

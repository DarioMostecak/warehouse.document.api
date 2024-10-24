// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Shipments.Exceptions
{
    public class NotFoundShipmentException : ExceptionModel
    {
        public NotFoundShipmentException(Guid id)
        : base(message: $"Shipment with id:{id} couldn't be found.") { }
    }
}

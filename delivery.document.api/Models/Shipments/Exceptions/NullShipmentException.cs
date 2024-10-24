// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Shipments.Exceptions
{
    public class NullShipmentException : ExceptionModel
    {
        public NullShipmentException()
         : base(message: "Shipment is null.") { }
    }
}

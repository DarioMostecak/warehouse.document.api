// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Shipments.Exceptions
{
    public class NullShipmentException : ExceptionModel
    {
        public NullShipmentException()
         : base(message: "Shipment is null.") { }
    }
}

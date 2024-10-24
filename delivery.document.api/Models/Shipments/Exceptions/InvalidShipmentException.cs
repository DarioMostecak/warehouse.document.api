// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Shipments.Exceptions
{
    public class InvalidShipmentException : ExceptionModel
    {
        public InvalidShipmentException()
          : base(message: "Invalid shipment. Please fix errors and try again.") { }

        public InvalidShipmentException(string parameterName, object parameterValue)
           : base(message: $"Invalid shipment, " +
                 $"parameter name: {parameterName}," +
                 $"parameter value: {parameterValue}")
        { }
    }
}

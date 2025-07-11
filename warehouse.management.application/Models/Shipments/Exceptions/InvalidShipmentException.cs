// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Shipments.Exceptions
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

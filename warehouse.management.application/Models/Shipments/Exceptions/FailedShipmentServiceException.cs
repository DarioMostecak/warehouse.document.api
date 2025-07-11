// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Shipments.Exceptions
{
    public class FailedShipmentServiceException : ExceptionModel
    {
        public FailedShipmentServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

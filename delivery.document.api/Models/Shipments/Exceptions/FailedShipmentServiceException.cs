// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Shipments.Exceptions
{
    public class FailedShipmentServiceException : ExceptionModel
    {
        public FailedShipmentServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

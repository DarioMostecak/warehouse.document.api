// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.DeliveryDocuments.Exceptions
{
    public class FailedDeliveryDocumentServiceException : ExceptionModel
    {
        public FailedDeliveryDocumentServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

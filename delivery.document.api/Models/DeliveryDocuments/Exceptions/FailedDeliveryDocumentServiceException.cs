// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.DeliveryDocuments.Exceptions
{
    public class FailedDeliveryDocumentServiceException : ExceptionModel
    {
        public FailedDeliveryDocumentServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

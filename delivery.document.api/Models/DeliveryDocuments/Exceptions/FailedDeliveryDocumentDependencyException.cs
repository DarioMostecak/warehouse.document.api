// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.DeliveryDocuments.Exceptions
{
    public class FailedDeliveryDocumentDependencyException : ExceptionModel
    {
        public FailedDeliveryDocumentDependencyException(Exception innerException)
            : base(message: "Failed dependency exception. Contact support.") { }
    }
}

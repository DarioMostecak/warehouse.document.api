// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.DeliveryDocuments.Exceptions
{
    public class FailedDeliveryDocumentDependencyException : ExceptionModel
    {
        public FailedDeliveryDocumentDependencyException(Exception innerException)
            : base(message: "Failed dependency exception. Contact support.") { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.DeliveryDocuments.Exceptions
{
    public class DeliveryDocumentDependencyException : ExceptionModel
    {
        public DeliveryDocumentDependencyException(Exception innerException)
           : base(message: "DeliveryDocument dependency error occurred, please contact support.", innerException)
        { }
    }
}

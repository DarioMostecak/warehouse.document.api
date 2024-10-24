// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.DeliveryDocuments.Exceptions
{
    public class DeliveryDocumentDependencyException : ExceptionModel
    {
        public DeliveryDocumentDependencyException(Exception innerException)
           : base(message: "DeliveryDocument dependency error occurred, please contact support.", innerException)
        { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.DeliveryDocuments.Exceptions
{
    public class DeliveryDocumentServiceException : ExceptionModel
    {
        public DeliveryDocumentServiceException(Exception innerException)
          : base(message: "DeliveryDocument service error, please contact support.", innerException)
        { }
    }
}

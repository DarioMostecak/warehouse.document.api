// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 202s Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.DeliveryDocuments.Exceptions
{
    public class DeliveryDocumentServiceException : ExceptionModel
    {
        public DeliveryDocumentServiceException(Exception innerException)
          : base(message: "DeliveryDocument service error, please contact support.", innerException)
        { }
    }
}

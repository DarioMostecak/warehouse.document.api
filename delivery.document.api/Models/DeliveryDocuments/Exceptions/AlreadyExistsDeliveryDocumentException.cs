// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.DeliveryDocuments.Exceptions
{
    public class AlreadyExistsDeliveryDocumentException : ExceptionModel
    {
        public AlreadyExistsDeliveryDocumentException(Exception innerException)
          : base(message: "DeliveryDocument with same id already exists.", innerException) { }
    }
}

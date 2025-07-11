// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.DeliveryDocuments.Exceptions
{
    public class AlreadyExistsDeliveryDocumentException : ExceptionModel
    {
        public AlreadyExistsDeliveryDocumentException(Exception innerException)
          : base(message: "DeliveryDocument with same id already exists.", innerException) { }
    }
}

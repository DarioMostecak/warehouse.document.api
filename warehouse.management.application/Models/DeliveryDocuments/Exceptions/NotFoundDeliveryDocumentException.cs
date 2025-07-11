// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.DeliveryDocuments.Exceptions
{
    public class NotFoundDeliveryDocumentException : ExceptionModel
    {
        public NotFoundDeliveryDocumentException(Guid id)
         : base(message: $"DeliveryDocument with id:{id} couldn't be found.")
        { }
    }
}

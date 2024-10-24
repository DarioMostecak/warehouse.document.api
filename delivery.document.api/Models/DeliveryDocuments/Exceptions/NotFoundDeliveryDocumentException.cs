// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.DeliveryDocuments.Exceptions
{
    public class NotFoundDeliveryDocumentException : ExceptionModel
    {
        public NotFoundDeliveryDocumentException(Guid id)
         : base(message: $"DeliveryDocument with id:{id} couldn't be found.")
        { }
    }
}

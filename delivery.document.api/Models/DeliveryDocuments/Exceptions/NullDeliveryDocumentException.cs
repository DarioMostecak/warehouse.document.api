// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.DeliveryDocuments.Exceptions
{
    public class NullDeliveryDocumentException : ExceptionModel
    {
        public NullDeliveryDocumentException()
           : base(message: "DeliveryDocument is null.") { }
    }
}

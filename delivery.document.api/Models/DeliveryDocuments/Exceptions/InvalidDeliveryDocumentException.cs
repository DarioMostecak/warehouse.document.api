// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.DeliveryDocuments.Exceptions
{
    public class InvalidDeliveryDocumentException : ExceptionModel
    {
        public InvalidDeliveryDocumentException()
            : base(message: "Invalid DeliveryDocument. Please fix errors and try again.") { }

        public InvalidDeliveryDocumentException(string parameterName, object parameterValue)
           : base(message: $"Invalid DeliveryDocument, " +
                 $"parameter name: {parameterName}," +
                 $"parameter value: {parameterValue}")
        { }
    }
}

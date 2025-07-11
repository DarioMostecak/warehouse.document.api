// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.DeliveryDocuments.Exceptions
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

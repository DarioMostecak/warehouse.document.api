// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;
using System.Collections;

namespace delivery.document.api.Models.Shipments.Exceptions
{
    public class ShipmentValidationException : ExceptionModel
    {
        public ShipmentValidationException(Exception innerException, IDictionary data)
          : base(message: innerException.Message, innerException, data: data)
        { }
    }
}

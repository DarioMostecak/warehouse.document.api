// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;
using System.Collections;

namespace delivery.document.api.Models.Addresses.Exceptions
{
    public class AddressValidationException : ExceptionModel
    {
        public AddressValidationException(Exception innerException, IDictionary data)
           : base(message: innerException.Message, innerException, data: data)
        { }
    }
}

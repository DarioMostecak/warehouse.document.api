// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;
using System.Collections;

namespace delivery.document.api.Models.Customers.Exceptions
{
    public class CustomerValidationException : ExceptionModel
    { 
        public CustomerValidationException(Exception innerException, IDictionary data)
            : base(message: innerException.Message, innerException, data: data)
        { }    
    }
}

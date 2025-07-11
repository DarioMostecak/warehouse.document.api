// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using System.Collections;
using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Customers.Exceptions
{
    public class CustomerValidationException : ExceptionModel
    {
        public CustomerValidationException(Exception innerException, IDictionary data)
            : base(message: innerException.Message, innerException, data: data)
        { }
    }
}

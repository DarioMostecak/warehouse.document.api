// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;
using System.Collections;

namespace delivery.document.api.Models.Orders.Exceptions
{
    public class OrderValidationException : ExceptionModel
    {
        public OrderValidationException(Exception innerException, IDictionary data)
          : base(message: innerException.Message, innerException, data: data)
        { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;
using System.Collections;

namespace delivery.document.api.Models.Products.Exceptions
{
    public class ProductValidationException : ExceptionModel
    {
        public ProductValidationException(Exception innerException, IDictionary data)
          : base(message: innerException.Message, innerException, data: data)
        { }
    }
}

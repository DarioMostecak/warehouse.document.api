// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Products.Exceptions
{
    public class InvalidProductException : ExceptionModel
    {
        public InvalidProductException()
          : base(message: "Invalid product. Please fix errors and try again.") { }

        public InvalidProductException(string parameterName, object parameterValue)
           : base(message: $"Invalid product, " +
                 $"parameter name: {parameterName}," +
                 $"parameter value: {parameterValue}")
        { }
    }
}

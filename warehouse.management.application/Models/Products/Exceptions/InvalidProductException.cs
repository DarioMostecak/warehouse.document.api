// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Products.Exceptions
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

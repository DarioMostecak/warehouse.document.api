// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Products.Exceptions
{
    public class ProductDependencyException : ExceptionModel
    {
        public ProductDependencyException(Exception innerException)
          : base(message: "Product dependency error occurred, please contact support.", innerException)
        { }
    }
}

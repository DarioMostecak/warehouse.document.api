// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Products.Exceptions
{
    public class ProductDependencyException : ExceptionModel
    {
        public ProductDependencyException(Exception innerException)
          : base(message: "Product dependency error occurred, please contact support.", innerException)
        { }
    }
}

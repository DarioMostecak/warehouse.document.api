// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Products.Exceptions
{
    public class ProductServiceException : ExceptionModel
    {
        public ProductServiceException(Exception innerException)
        : base(message: "Product service error, please contact support.", innerException)
        { }
    }
}

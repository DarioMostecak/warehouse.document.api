// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Products.Exceptions
{
    public class ProductServiceException : ExceptionModel
    {
        public ProductServiceException(Exception innerException)
        : base(message: "Product service error, please contact support.", innerException)
        { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Products.Exceptions
{
    public class FailedProductDependencyException : ExceptionModel
    {
        public FailedProductDependencyException(Exception innerException)
           : base(message: "Failed dependency exception. Contact support.") { }
    }
}

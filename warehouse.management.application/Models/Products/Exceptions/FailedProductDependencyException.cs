// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Products.Exceptions
{
    public class FailedProductDependencyException : ExceptionModel
    {
        public FailedProductDependencyException(Exception innerException)
           : base(message: "Failed dependency exception. Contact support.") { }
    }
}

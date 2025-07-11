// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Products.Exceptions
{
    public class FailedProductServiceException : ExceptionModel
    {
        public FailedProductServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

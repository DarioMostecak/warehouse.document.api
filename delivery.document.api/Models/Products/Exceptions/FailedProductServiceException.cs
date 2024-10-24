// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Products.Exceptions
{
    public class FailedProductServiceException : ExceptionModel
    {
        public FailedProductServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

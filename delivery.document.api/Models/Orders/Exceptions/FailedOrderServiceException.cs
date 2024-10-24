// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Orders.Exceptions
{
    public class FailedOrderServiceException : ExceptionModel
    {
        public FailedOrderServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

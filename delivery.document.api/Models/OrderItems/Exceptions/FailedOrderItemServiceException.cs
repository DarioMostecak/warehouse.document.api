// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.OrderItems.Exceptions
{
    public class FailedOrderItemServiceException : ExceptionModel
    {
        public FailedOrderItemServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

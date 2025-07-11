// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.OrderItems.Exceptions
{
    public class FailedOrderItemServiceException : ExceptionModel
    {
        public FailedOrderItemServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

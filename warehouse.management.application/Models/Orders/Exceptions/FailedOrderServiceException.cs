// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Orders.Exceptions
{
    public class FailedOrderServiceException : ExceptionModel
    {
        public FailedOrderServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.") { }
    }
}

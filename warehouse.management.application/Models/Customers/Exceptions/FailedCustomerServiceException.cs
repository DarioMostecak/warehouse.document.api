// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Customers.Exceptions
{
    public class FailedCustomerServiceException : ExceptionModel
    {
        public FailedCustomerServiceException(Exception innerException)
            : base(message: "Failed service exception. Contact support.") { }
    }
}

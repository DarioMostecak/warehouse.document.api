// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Customers.Exceptions
{
    public class FailedCustomerDependencyException : ExceptionModel
    {
        public FailedCustomerDependencyException(Exception innerException)
            : base(message: "Failed dependency exception. Contact support.") { }
    }
}

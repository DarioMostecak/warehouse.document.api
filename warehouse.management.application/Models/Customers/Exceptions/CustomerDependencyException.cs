// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Customers.Exceptions
{
    public class CustomerDependencyException : ExceptionModel
    {
        public CustomerDependencyException(Exception innerException)
            : base(message: "Customer dependency error occurred, please contact support.", innerException)
        { }
    }
}

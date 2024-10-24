// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Customers.Exceptions
{
    public class CustomerDependencyException : ExceptionModel
    {
        public CustomerDependencyException(Exception innerException)
            : base(message: "Customer dependency error occurred, please contact support.", innerException)
        { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Customers.Exceptions
{
    public class CustomerServiceException : ExceptionModel
    {
        public CustomerServiceException(Exception innerException)
           : base(message: "Customer service error, please contact support.", innerException)
        { }
    }
}

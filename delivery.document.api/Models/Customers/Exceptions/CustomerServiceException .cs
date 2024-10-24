// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Customers.Exceptions
{
    public class CustomerServiceException : ExceptionModel
    {
        public CustomerServiceException(Exception innerException)
           : base(message: "Customer service error, please contact support.", innerException)
        { }
    }
}

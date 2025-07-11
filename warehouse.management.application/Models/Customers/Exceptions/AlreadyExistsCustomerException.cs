// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Customers.Exceptions
{
    public class AlreadyExistsCustomerException : ExceptionModel
    {
        public AlreadyExistsCustomerException(Exception innerException)
            : base(message: "Customer with same id already exists.", innerException) { }
    }
}

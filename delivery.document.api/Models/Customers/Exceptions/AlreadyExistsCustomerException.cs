// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Customers.Exceptions
{
    public class AlreadyExistsCustomerException : ExceptionModel
    {
        public AlreadyExistsCustomerException(Exception innerException)
            : base(message: "Customer with same id already exists.", innerException) { }
    }
}

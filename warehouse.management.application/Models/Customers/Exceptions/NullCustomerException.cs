// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Customers.Exceptions
{
    public class NullCustomerException : ExceptionModel
    {
        public NullCustomerException()
            : base(message: "Customer is null.") { }
    }
}

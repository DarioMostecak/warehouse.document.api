// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Customers.Exceptions
{
    public class NullCustomerException : ExceptionModel
    {
        public NullCustomerException()
            : base(message: "Customer is null.") { }
    }
}

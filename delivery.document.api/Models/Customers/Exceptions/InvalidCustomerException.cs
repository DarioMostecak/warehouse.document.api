// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Customers.Exceptions
{
    public class InvalidCustomerException  :ExceptionModel
    {
        public InvalidCustomerException()
            : base(message: "Invalid customer. Please fix errors and try again.") { }

        public InvalidCustomerException(string parameterName, object parameterValue)
           : base(message: $"Invalid customer, " +
                 $"parameter name: {parameterName}," +
                 $"parameter value: {parameterValue}")
        { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Customers.Exceptions
{
    public class FailedCustomerServiceException : ExceptionModel
    {
        public FailedCustomerServiceException(Exception innerException)
            : base(message: "Failed service exception. Contact support.") { }
    }
}

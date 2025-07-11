// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Addresses.Exceptions
{
    public class AddressServiceException : ExceptionModel
    {
        public AddressServiceException(Exception innerException)
           : base(message: "Address service error, please contact support.", innerException)
        { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Addresses.Exceptions
{
    public class AddressServiceException : ExceptionModel
    {
        public AddressServiceException(Exception innerException)
           : base(message: "Address service error, please contact support.", innerException)
        { }
    }
}

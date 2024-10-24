// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Addresses.Exceptions
{
    public class FailedAddressServiceException : ExceptionModel
    {
        public FailedAddressServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.")
        { }
    }
}

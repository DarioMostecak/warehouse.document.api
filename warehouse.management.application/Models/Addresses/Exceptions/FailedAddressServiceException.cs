// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Addresses.Exceptions
{
    public class FailedAddressServiceException : ExceptionModel
    {
        public FailedAddressServiceException(Exception innerException)
           : base(message: "Failed service exception. Contact support.")
        { }
    }
}

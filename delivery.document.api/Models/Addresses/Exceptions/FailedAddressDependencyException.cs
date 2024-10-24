// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Addresses.Exceptions
{
    public class FailedAddressDependencyException : ExceptionModel
    {
        public FailedAddressDependencyException(Exception innerException)
            : base(message: "Failed dependency exception. Contact support.")
        { }
    }
}

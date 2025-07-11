// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Addresses.Exceptions
{
    public class FailedAddressDependencyException : ExceptionModel
    {
        public FailedAddressDependencyException(Exception innerException)
            : base(message: "Failed dependency exception. Contact support.")
        { }
    }
}

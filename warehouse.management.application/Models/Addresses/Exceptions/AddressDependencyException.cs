// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------



using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Addresses.Exceptions
{
    public class AddressDependencyException : ExceptionModel
    {
        public AddressDependencyException(Exception innerException)
            : base(message: "Address dependency error occurred, please contact support.", innerException)
        { }
    }
}

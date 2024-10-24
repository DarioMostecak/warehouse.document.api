// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Addresses.Exceptions
{
    public class AddressDependencyException : ExceptionModel
    {
        public AddressDependencyException(Exception innerException)
            : base(message: "Address dependency error occurred, please contact support.", innerException)
        { }        
    }
}

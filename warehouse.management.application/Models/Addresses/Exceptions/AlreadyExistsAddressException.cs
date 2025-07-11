// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Addresses.Exceptions
{
    public class AlreadyExistsAddressException : ExceptionModel
    {
        public AlreadyExistsAddressException(Exception innerException)
            : base(message: "Address with same id already exists.", innerException) { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Addresses.Exceptions
{
    public class AlreadyExistsAddressException : ExceptionModel
    {
        public AlreadyExistsAddressException(Exception innerException)
            : base(message: "Address with same id already exists.", innerException) { }
    }
}

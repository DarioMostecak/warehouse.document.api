// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Addresses.Exceptions
{
    public class NotFoundAddressException : ExceptionModel
    {
        public NotFoundAddressException(Guid id)
           : base(message: $"Address with id:{id} couldn't be found.")
        { }
    }
}

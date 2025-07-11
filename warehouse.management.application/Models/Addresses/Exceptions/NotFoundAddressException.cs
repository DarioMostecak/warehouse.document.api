// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Addresses.Exceptions
{
    public class NotFoundAddressException : ExceptionModel
    {
        public NotFoundAddressException(Guid id)
           : base(message: $"Address with id:{id} couldn't be found.")
        { }
    }
}

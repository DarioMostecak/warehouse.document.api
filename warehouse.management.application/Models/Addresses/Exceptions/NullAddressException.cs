// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Addresses.Exceptions
{
    public class NullAddressException : ExceptionModel
    {
        public NullAddressException()
           : base(message: "Address is null.")
        { }
    }
}

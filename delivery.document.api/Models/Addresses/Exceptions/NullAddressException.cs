// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Addresses.Exceptions
{
    public class NullAddressException : ExceptionModel
    {
        public NullAddressException()
           : base(message: "Address is null.")
        { }
    }
}

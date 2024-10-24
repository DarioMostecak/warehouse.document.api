// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Orders.Exceptions
{
    public class NullOrderException : ExceptionModel
    {
        public NullOrderException()
           : base(message: "Order is null.") { }
    }
}

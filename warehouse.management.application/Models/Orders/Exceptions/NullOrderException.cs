// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Orders.Exceptions
{
    public class NullOrderException : ExceptionModel
    {
        public NullOrderException()
           : base(message: "Order is null.") { }
    }
}

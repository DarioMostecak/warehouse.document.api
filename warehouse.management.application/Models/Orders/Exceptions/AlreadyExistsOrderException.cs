// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Orders.Exceptions
{
    public class AlreadyExistsOrderException : ExceptionModel
    {

        public AlreadyExistsOrderException(Exception innerException)
            : base(message: "Order with same id already exists.", innerException) { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Orders.Exceptions
{
    public class AlreadyExistsOrderException : ExceptionModel
    {

        public AlreadyExistsOrderException(Exception innerException)
            : base(message: "Order with same id already exists.", innerException) { }
    }
}

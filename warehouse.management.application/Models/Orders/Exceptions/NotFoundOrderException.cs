// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Orders.Exceptions
{
    public class NotFoundOrderException : ExceptionModel
    {
        public NotFoundOrderException(Guid id)
      : base(message: $"Order with id:{id} couldn't be found.")
        { }
    }
}

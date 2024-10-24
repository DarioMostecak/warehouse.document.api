// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Orders.Exceptions
{
    public class NotFoundOrderException : ExceptionModel
    {
        public NotFoundOrderException(Guid id)
      : base(message: $"Order with id:{id} couldn't be found.")
        { }
    }
}

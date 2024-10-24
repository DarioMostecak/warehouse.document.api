// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Products.Exceptions
{
    public class NotFoundProductException : ExceptionModel
    {
        public NotFoundProductException(Guid id)
         : base(message: $"Product with id:{id} couldn't be found.") { }
    }
}

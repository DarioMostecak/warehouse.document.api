// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Products.Exceptions
{
    public class NotFoundProductException : ExceptionModel
    {
        public NotFoundProductException(Guid id)
         : base(message: $"Product with id:{id} couldn't be found.") { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Products.Exceptions
{
    public class NullProductException : ExceptionModel
    {
        public NullProductException()
         : base(message: "Product is null.") { }
    }
}

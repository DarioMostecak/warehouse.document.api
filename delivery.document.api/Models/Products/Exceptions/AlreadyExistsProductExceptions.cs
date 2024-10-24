// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Products.Exceptions
{
    public class AlreadyExistsProductExceptions : ExceptionModel
    {
        public AlreadyExistsProductExceptions(Exception innerException)
           : base(message: "Product with same id already exists.", innerException) { }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

namespace delivery.document.api.Shared.ErrorResponseObjects
{
    public class CreatedObjectResult : ObjectResult
    {
        public CreatedObjectResult(object value) : base(value) =>
            StatusCode = StatusCodes.Status201Created;
    }
}

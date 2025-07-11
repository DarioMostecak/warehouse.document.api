// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak. All rights reserved.
// ---------------------------------------------------------------

using System.Collections;
using warehouse.management.application.Models.ValidationProblemDetails;

namespace warehouse.management.application.Models.ExceptionModels
{
    public class HttpResponseNotFoundException : HttpResponseException
    {
        public HttpResponseNotFoundException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseNotFoundException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseNotFoundException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetail problemDetail) : base(responseMessage, problemDetail.Title)
        {
            this.AddData((IDictionary)problemDetail.Errors);
        }
    }
}

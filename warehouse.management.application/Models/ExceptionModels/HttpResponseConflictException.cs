// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak. All rights reserved.
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System.Collections;
using warehouse.management.application.Models.ValidationProblemDetails;

namespace warehouse.management.application.Models.ExceptionModels
{

    public class HttpResponseConflictException : HttpResponseException
    {
        public HttpResponseConflictException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseConflictException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseConflictException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetail problemDetail) : base(responseMessage, problemDetail.Title)
        {
            this.AddData((IDictionary)problemDetail.Errors);
        }
    }
}

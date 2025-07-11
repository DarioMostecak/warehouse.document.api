// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak. All rights reserved.
// ---------------------------------------------------------------

using System.Collections;
using warehouse.management.application.Models.ValidationProblemDetails;

namespace warehouse.management.application.Models.ExceptionModels
{
    public class HttpResponseBadRequestException : HttpResponseException
    {
        public HttpResponseBadRequestException()
            : base(httpResponseMessage: default, message: default) { }

        public HttpResponseBadRequestException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseBadRequestException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetail problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak. All rights reserved.
// ---------------------------------------------------------------

using System.Collections;
using warehouse.management.application.Models.ValidationProblemDetails;

namespace warehouse.management.application.Models.ExceptionModels
{
    public class HttpResponseInternalServerErrorException : HttpResponseException
    {
        public HttpResponseInternalServerErrorException(HttpResponseMessage responseMessage, string message)
           : base(responseMessage, message) { }

        public HttpResponseInternalServerErrorException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetail problemDetail) : base(responseMessage, problemDetail.Title)
        {
            this.AddData((IDictionary)problemDetail.Errors);
        }
    }
}

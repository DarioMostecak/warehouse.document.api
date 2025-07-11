// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak. All rights reserved.
// ---------------------------------------------------------------

namespace warehouse.management.application.Models.ExceptionModels
{
    public class HttpResponseException : ExceptionModel
    {
        public HttpResponseException(HttpResponseMessage httpResponseMessage, string message)
            : base(message) => this.HttpResponseMessage = httpResponseMessage;

        public HttpResponseMessage HttpResponseMessage { get; private set; }
    }
}

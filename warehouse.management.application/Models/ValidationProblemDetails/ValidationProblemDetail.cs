// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak. All rights reserved.
// ---------------------------------------------------------------

namespace warehouse.management.application.Models.ValidationProblemDetails
{
    public class ValidationProblemDetail
    {
        public int Status { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public IDictionary<string, string[]>? Errors { get; }
    }
}

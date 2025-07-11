using System.Collections;
using warehouse.management.application.Models.ValidationProblemDetails;

namespace warehouse.management.application.Models.ExceptionModels
{
    public class HttpResponseUnauthorizedException : HttpResponseException
    {
        public HttpResponseUnauthorizedException(HttpResponseMessage responseMessage, string message)
            : base(responseMessage, message) { }

        public HttpResponseUnauthorizedException(
            HttpResponseMessage responseMessage,
            ValidationProblemDetail problemDetails) : base(responseMessage, problemDetails.Title)
        {
            this.AddData((IDictionary)problemDetails.Errors);
        }
    }
}

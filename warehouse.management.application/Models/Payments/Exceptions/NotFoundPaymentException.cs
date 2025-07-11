// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Payments.Exceptions
{
    public class NotFoundPaymentException : ExceptionModel
    {
        public NotFoundPaymentException(Guid id)
          : base(message: $"Payment with id:{id} couldn't be found.") { }
    }
}

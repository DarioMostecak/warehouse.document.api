// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Payments.Exceptions
{
    public class NotFoundPaymentException : ExceptionModel
    {
        public NotFoundPaymentException(Guid id)
          : base(message: $"Payment with id:{id} couldn't be found.") { }
    }
}

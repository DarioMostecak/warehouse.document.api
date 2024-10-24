// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Payments.Exceptions
{
    public class AlreadyExistsPaymentException : ExceptionModel
    {
        public AlreadyExistsPaymentException(Exception innerException)
            : base(message: "Payment with same id already exists.", innerException) { }
    }
}

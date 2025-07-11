// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Payments.Exceptions
{
    public class AlreadyExistsPaymentException : ExceptionModel
    {
        public AlreadyExistsPaymentException(Exception innerException)
            : base(message: "Payment with same id already exists.", innerException) { }
    }
}

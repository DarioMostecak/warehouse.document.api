// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Payments.Exceptions
{
    public class NullPaymentException : ExceptionModel
    {
        public NullPaymentException()
          : base(message: "Payment is null.") { }
    }
}

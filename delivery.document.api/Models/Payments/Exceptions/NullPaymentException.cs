// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Payments.Exceptions
{
    public class NullPaymentException : ExceptionModel
    {
        public NullPaymentException()
          : base(message: "Payment is null.") { }
    }
}

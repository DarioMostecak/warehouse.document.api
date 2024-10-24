// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;
using System.Collections;

namespace delivery.document.api.Models.Payments.Exceptions
{
    public class PaymentValidationException : ExceptionModel
    {
        public PaymentValidationException(Exception innerException, IDictionary data)
          : base(message: innerException.Message, innerException, data: data)
        { }
    }
}

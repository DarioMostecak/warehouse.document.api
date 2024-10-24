// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Customers.Exceptions
{
    public class NotFoundCustomerException : ExceptionModel
    {
        public NotFoundCustomerException(Guid id)
          : base(message: $"Customer with id:{id} couldn't be found.")
        { }

    }
}

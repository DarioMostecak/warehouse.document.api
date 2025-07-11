// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Customers.Exceptions
{
    public class NotFoundCustomerException : ExceptionModel
    {
        public NotFoundCustomerException(Guid id)
          : base(message: $"Customer with id:{id} couldn't be found.")
        { }

    }
}

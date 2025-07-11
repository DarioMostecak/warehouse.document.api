// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak.
// ---------------------------------------------------------------


using warehouse.management.application.Models.ExceptionModels;

namespace warehouse.management.application.Models.Addresses.Exceptions
{
    public class InvalidAddressException : ExceptionModel
    {
        public InvalidAddressException()
          : base(message: "Invalid address. Please fix errors and try again.")
        { }

        public InvalidAddressException(string parameterName, object parameterValue)
            : base(message: $"Invalid address, " +
                  $"parameter name: {parameterName}," +
                  $"parameter value: {parameterValue}")
        { }
    }
}

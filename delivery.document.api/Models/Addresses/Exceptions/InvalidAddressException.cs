using delivery.document.api.Models.ExceptionModels;

namespace delivery.document.api.Models.Addresses.Exceptions
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

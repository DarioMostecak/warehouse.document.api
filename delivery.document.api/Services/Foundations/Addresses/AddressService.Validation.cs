// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Addresses.Exceptions;
using delivery.document.api.Models.Addresses;

namespace delivery.document.api.Services.Foundations.Addresses
{
    public partial class AddressService
    {
        private void ValidateAddressOnCreate(Address address)
        {
            ValidateAddressIsNull(address);

            Validate(
                (rule: IsInvalid(address.AddressID), parameter: nameof(Address.AddressID)),
                (rule: IsInvalid(address.AddressType), parameter: nameof(Address.AddressType)),
                (rule: IsInvalid(address.AddressLine1), parameter: nameof(Address.AddressLine1)),
                (rule: IsInvalid(address.AddressLine2), parameter: nameof(Address.AddressLine2)),
                (rule: IsInvalid(address.City), parameter: nameof(Address.City)),
                (rule: IsInvalid(address.State), parameter: nameof(Address.State)),
                (rule: IsInvalid(address.PostalCode), parameter: nameof(Address.PostalCode)),
                (rule: IsInvalid(address.Country), parameter: nameof(Address.Country)),
                (rule: IsInvalid(address.CreatedAt), parameter: nameof(Address.CreatedAt)),
                (rule: IsInvalid(address.UpdatedAt), parameter: nameof(Address.UpdatedAt))
            );
        }

        private void ValidateAddressOnModify(Address address)
        {
            ValidateAddressIsNull(address);

            Validate(
                (rule: IsInvalid(address.AddressID), parameter: nameof(Address.AddressID)),
                (rule: IsInvalid(address.AddressType), parameter: nameof(Address.AddressType)),
                (rule: IsInvalid(address.AddressLine1), parameter: nameof(Address.AddressLine1)),
                (rule: IsInvalid(address.AddressLine2), parameter: nameof(Address.AddressLine2)),
                (rule: IsInvalid(address.City), parameter: nameof(Address.City)),
                (rule: IsInvalid(address.State), parameter: nameof(Address.State)),
                (rule: IsInvalid(address.PostalCode), parameter: nameof(Address.PostalCode)),
                (rule: IsInvalid(address.Country), parameter: nameof(Address.Country)),
                (rule: IsInvalid(address.CreatedAt), parameter: nameof(Address.CreatedAt)),
                (rule: IsInvalid(address.UpdatedAt), parameter: nameof(Address.UpdatedAt)),
                (rule: IsSame(address.CreatedAt, address.UpdatedAt, nameof(Address.UpdatedAt)),
                parameter: nameof(Address.UpdatedAt))
            );
        }

        private static void ValidateAgainstStorageAddressOnModify(
            Address inputAddress, Address storageAddress)
        {
            Validate(
                (rule: IsNotSame(inputAddress.AddressID, storageAddress.AddressID, nameof(Address.AddressID)),
                parameter: nameof(Address.AddressID)),

                (rule: IsNotSame(inputAddress.CreatedAt, storageAddress.CreatedAt, nameof(Address.CreatedAt)),
                parameter: nameof(Address.CreatedAt)),

                (rule: IsSame(inputAddress.UpdatedAt, storageAddress.UpdatedAt, nameof(Address.UpdatedAt)),
                parameter: nameof(Address.UpdatedAt))
            );
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "ID is required."
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text) || text.Length > 100,
            Message = "Text must not exceed 100 characters and cannot be null or whitespace."
        };

        private static dynamic IsInvalid(DateTime date) => new
        {
            Condition = date == default,
            Message = "Date is required."
        };

        private static dynamic IsNotSame(Guid firstId, Guid secondId, string secondIdName) => new
        {
            Condition = firstId != secondId,
            Message = $"ID does not match with {secondIdName}."
        };

        private static dynamic IsNotSame(DateTime firstDate, DateTime secondDate, string secondDateName) => new
        {
            Condition = Math.Abs((firstDate - secondDate).TotalSeconds) >= 1,
            Message = $"Date does not match with {secondDateName}."
        };

        private static dynamic IsSame(DateTime firstDate, DateTime secondDate, string secondDateName) => new
        {
            Condition = Math.Abs((firstDate - secondDate).TotalSeconds) <= 1,
            Message = $"Date matches with {secondDateName}."
        };

        private static void ValidateAddressIsNull(Address address)
        {
            if (address == null)
            {
                throw new NullAddressException();
            }
        }

        private static void ValidateAddressIdIsNull(Guid addressID)
        {
            if (IsInvalid(addressID))
            {
                var invalidCategorytException = new InvalidAddressException(nameof(Address.AddressID), addressID);
                throw invalidCategorytException;
            }
        }

        private static void ValidateStorageAddress(Address storageAddress,
            Guid addressID)
        {
            if (storageAddress is null) throw new NotFoundAddressException(addressID);
        }

        private static void Validate(params (dynamic rule, string parameter)[] validations)
        {
            var invalidAddressException = new InvalidAddressException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidAddressException.UpsertDataList(key: parameter, value: rule.Message);
                }
            }

            invalidAddressException.ThrowIfContainsErrors();
        }
    }
}

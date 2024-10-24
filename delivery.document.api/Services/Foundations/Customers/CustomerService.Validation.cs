// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Customers.Exceptions;
using delivery.document.api.Models.Customers;

namespace delivery.document.api.Services.Foundations.Customers
{
    public partial class CustomerService
    {
        private void ValidateCustomerOnCreate(Customer customer)
        {
            ValidateCustomerIsNull(customer);

            Validate(
                (rule: IsInvalid(customer.CustomerID), parameter: nameof(Customer.CustomerID)),
                (rule: IsInvalid(customer.FirstName), parameter: nameof(Customer.FirstName)),
                (rule: IsInvalid(customer.LastName), parameter: nameof(Customer.LastName)),
                (rule: IsInvalid(customer.Email), parameter: nameof(Customer.Email)),
                (rule: IsInvalid(customer.PhoneNumber), parameter: nameof(Customer.PhoneNumber)),
                (rule: IsInvalid(customer.City), parameter: nameof(Customer.City)),
                (rule: IsInvalid(customer.State), parameter: nameof(Customer.State)),
                (rule: IsInvalid(customer.PostalCode), parameter: nameof(Customer.PostalCode)),
                (rule: IsInvalid(customer.Country), parameter: nameof(Customer.Country)),
                (rule: IsInvalid(customer.CreatedAt), parameter: nameof(Customer.CreatedAt)),
                (rule: IsInvalid(customer.UpdatedAt), parameter: nameof(Customer.UpdatedAt))
            );
        }

        private void ValidateCustomerOnModify(Customer customer)
        {
            ValidateCustomerIsNull(customer);

            Validate(
                (rule: IsInvalid(customer.CustomerID), parameter: nameof(Customer.CustomerID)),
                (rule: IsInvalid(customer.FirstName), parameter: nameof(Customer.FirstName)),
                (rule: IsInvalid(customer.LastName), parameter: nameof(Customer.LastName)),
                (rule: IsInvalid(customer.Email), parameter: nameof(Customer.Email)),
                (rule: IsInvalid(customer.PhoneNumber), parameter: nameof(Customer.PhoneNumber)),
                (rule: IsInvalid(customer.City), parameter: nameof(Customer.City)),
                (rule: IsInvalid(customer.State), parameter: nameof(Customer.State)),
                (rule: IsInvalid(customer.PostalCode), parameter: nameof(Customer.PostalCode)),
                (rule: IsInvalid(customer.Country), parameter: nameof(Customer.Country)),
                (rule: IsInvalid(customer.CreatedAt), parameter: nameof(Customer.CreatedAt)),
                (rule: IsInvalid(customer.UpdatedAt), parameter: nameof(Customer.UpdatedAt)),
                (rule: IsSame(customer.CreatedAt, customer.UpdatedAt, nameof(Customer.UpdatedAt)),
                parameter: nameof(Customer.UpdatedAt))
            );
        }

        private static void ValidateAgainstStorageCustomerOnModify(
            Customer inputCustomer, Customer storageCustomer)
        {
            Validate(
                (rule: IsNotSame(inputCustomer.CustomerID, storageCustomer.CustomerID, nameof(Customer.CustomerID)),
                parameter: nameof(Customer.CustomerID)),

                (rule: IsNotSame(inputCustomer.CreatedAt, storageCustomer.CreatedAt, nameof(Customer.CreatedAt)),
                parameter: nameof(Customer.CreatedAt)),

                (rule: IsSame(inputCustomer.UpdatedAt, storageCustomer.UpdatedAt, nameof(Customer.UpdatedAt)),
                parameter: nameof(Customer.UpdatedAt))
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

        private static void ValidateCustomerIsNull(Customer customer)
        {
            if (customer == null)
            {
                throw new NullCustomerException();
            }
        }

        private static void ValidateCustomerIdIsNull(Guid customerId)
        {
            if (IsInvalid(customerId))
            {
                var invalidCustomerException = new InvalidCustomerException(nameof(Customer.CustomerID), customerId);
                throw invalidCustomerException;
            }
        }

        private static void ValidateStorageCustomer(Customer storageCustomer, Guid customerId)
        {
            if (storageCustomer is null) throw new NotFoundCustomerException(customerId);
        }

        private static void Validate(params (dynamic rule, string parameter)[] validations)
        {
            var invalidCustomerException = new InvalidCustomerException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidCustomerException.UpsertDataList(key: parameter, value: rule.Message);
                }
            }

            invalidCustomerException.ThrowIfContainsErrors();
        }
    }
}
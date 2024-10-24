// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Orders.Exceptions;
using delivery.document.api.Models.Orders;


namespace delivery.document.api.Services.Foundations.Orders
{
    public partial class OrderService
    {
        private void ValidateOrderOnCreate(Order order)
        {
            ValidateOrderIsNull(order);

            Validate(
                (rule: IsInvalid(order.OrderID), parameter: nameof(Order.OrderID)),
                (rule: IsInvalid(order.ProductID), parameter: nameof(Order.ProductID)),
                (rule: IsInvalid(order.AddressID), parameter: nameof(Order.AddressID)),
                (rule: IsInvalid(order.OrderDate), parameter: nameof(Order.OrderDate)),
                (rule: IsInvalid(order.Status), parameter: nameof(Order.Status)),
                (rule: IsInvalid(order.TotalAmount), parameter: nameof(Order.TotalAmount)),
                (rule: IsInvalid(order.ShippingCost), parameter: nameof(Order.ShippingCost)),
                (rule: IsInvalid(order.CreatedAt), parameter: nameof(Order.CreatedAt)),
                (rule: IsNotSame(order.CreatedAt, order.UpdatedAt, nameof(Order.UpdatedAt)),
                parameter: nameof(Order.UpdatedAt))
            );
        }

        private void ValidateOrderOnModify(Order order)
        {
            ValidateOrderIsNull(order);

            Validate(
                (rule: IsInvalid(order.OrderID), parameter: nameof(Order.OrderID)),
                (rule: IsInvalid(order.ProductID), parameter: nameof(Order.ProductID)),
                (rule: IsInvalid(order.AddressID), parameter: nameof(Order.AddressID)),
                (rule: IsInvalid(order.OrderDate), parameter: nameof(Order.OrderDate)),
                (rule: IsInvalid(order.Status), parameter: nameof(Order.Status)),
                (rule: IsInvalid(order.TotalAmount), parameter: nameof(Order.TotalAmount)),
                (rule: IsInvalid(order.ShippingCost), parameter: nameof(Order.ShippingCost)),
                (rule: IsInvalid(order.CreatedAt), parameter: nameof(Order.CreatedAt)),
                (rule: IsNotSame(order.CreatedAt, order.UpdatedAt, nameof(Order.UpdatedAt)),
                parameter: nameof(Order.UpdatedAt))
            );
        }

        private static void ValidateAgainstStorageOrderOnModify(
            Order inputOrder, Order storageOrder)
        {
            Validate(
                (rule: IsNotSame(inputOrder.OrderID, storageOrder.OrderID, nameof(Order.OrderID)),
                parameter: nameof(Order.OrderID)),
                (rule: IsNotSame(inputOrder.ProductID, storageOrder.ProductID, nameof(Order.ProductID)),
                parameter: nameof(Order.OrderID)),
                (rule: IsNotSame(inputOrder.AddressID, storageOrder.AddressID, nameof(Order.AddressID)),
                parameter: nameof(Order.AddressID)),
                (rule: IsNotSame(inputOrder.CreatedAt, storageOrder.CreatedAt, nameof(Order.CreatedAt)),
                parameter: nameof(Order.CreatedAt)),
                (rule: IsSame(inputOrder.UpdatedAt, storageOrder.UpdatedAt, nameof(Order.UpdatedAt)),
                parameter: nameof(Order.UpdatedAt))
            );
        }

        private static void ValidateOrderIsNull(Order order)
        {
            if (order == null)
            {
                throw new NullOrderException();
            }
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

        private static dynamic IsInvalid(decimal amount) => new
        {
            Condition = amount < 0,
            Message = "Amount must be greater than or equal to zero."
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

        private static void ValidateOrderIdIsNull(Guid OrderID)
        {
            if (OrderID == Guid.Empty)
            {
                throw new InvalidOrderException(nameof(Order.OrderID), OrderID);
            }
        }

        private static void ValidateStorageOrder(Order storageOrder, Guid orderID)
        {
            if (storageOrder == null)
            {
                throw new NotFoundOrderException(orderID);
            }
        }

        private static void Validate(params (dynamic rule, string parameter)[] validations)
        {
            var invalidOrderException = new InvalidOrderException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidOrderException.UpsertDataList(key: parameter, value: rule.Message);
                }
            }

            invalidOrderException.ThrowIfContainsErrors();
        }
    }

}

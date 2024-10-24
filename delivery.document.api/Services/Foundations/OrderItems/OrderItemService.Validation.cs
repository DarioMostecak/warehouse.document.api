// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.OrderItems.Exceptions;
using delivery.document.api.Models.OrderItems;

namespace delivery.document.api.Services.Foundations.OrderItems
{
    public partial class OrderItemService
    {
        private void ValidateOrderItemOnCreate(OrderItem orderItem)
        {
            ValidateOrderItemIsNull(orderItem);

            Validate(
                (rule: IsInvalid(orderItem.OrderItemID), parameter: nameof(OrderItem.OrderItemID)),
                (rule: IsInvalid(orderItem.OrderID), parameter: nameof(OrderItem.OrderID)),
                (rule: IsInvalid(orderItem.ProductID), parameter: nameof(OrderItem.ProductID)),
                (rule: IsInvalid(orderItem.Quantity), parameter: nameof(OrderItem.Quantity)),
                (rule: IsInvalid(orderItem.UnitPrice), parameter: nameof(OrderItem.UnitPrice)),
                (rule: IsInvalid(orderItem.TotalPrice), parameter: nameof(OrderItem.TotalPrice)),
                (rule: IsInvalid(orderItem.CreatedAt), parameter: nameof(OrderItem.CreatedAt)),
                (rule: IsInvalid(orderItem.UpdatedAt), parameter: nameof(OrderItem.UpdatedAt))
            );
        }

        private void ValidateOrderItemOnModify(OrderItem orderItem)
        {
            ValidateOrderItemIsNull(orderItem);

            Validate(
                (rule: IsInvalid(orderItem.OrderItemID), parameter: nameof(OrderItem.OrderItemID)),
                (rule: IsInvalid(orderItem.OrderID), parameter: nameof(OrderItem.OrderID)),
                (rule: IsInvalid(orderItem.ProductID), parameter: nameof(OrderItem.ProductID)),
                (rule: IsInvalid(orderItem.Quantity), parameter: nameof(OrderItem.Quantity)),
                (rule: IsInvalid(orderItem.UnitPrice), parameter: nameof(OrderItem.UnitPrice)),
                (rule: IsInvalid(orderItem.TotalPrice), parameter: nameof(OrderItem.TotalPrice)),
                (rule: IsInvalid(orderItem.CreatedAt), parameter: nameof(OrderItem.CreatedAt)),
                (rule: IsInvalid(orderItem.UpdatedAt), parameter: nameof(OrderItem.UpdatedAt)),
                (rule: IsSame(orderItem.CreatedAt, orderItem.UpdatedAt, nameof(OrderItem.UpdatedAt)),
                 parameter: nameof(OrderItem.UpdatedAt))
            );
        }

        private static void ValidateAgainstStorageOrderItemOnModify(
            OrderItem inputOrderItem, OrderItem storageOrderItem)
        {
            Validate(
                (rule: IsNotSame(inputOrderItem.OrderItemID, storageOrderItem.OrderItemID, nameof(OrderItem.OrderItemID)),
                 parameter: nameof(OrderItem.OrderItemID)),
                (rule: IsNotSame(inputOrderItem.CreatedAt, storageOrderItem.CreatedAt, nameof(OrderItem.CreatedAt)),
                 parameter: nameof(OrderItem.CreatedAt)),
                (rule: IsSame(inputOrderItem.UpdatedAt, storageOrderItem.UpdatedAt, nameof(OrderItem.UpdatedAt)),
                 parameter: nameof(OrderItem.UpdatedAt))
            );
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "ID is required."
        };

        private static dynamic IsInvalid(int number) => new
        {
            Condition = number <= 0,
            Message = "Quantity must be greater than zero."
        };

        private static dynamic IsInvalid(decimal amount) => new
        {
            Condition = amount < 0,
            Message = "Amount must not be negative."
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

        private static void ValidateOrderItemIdIsNull(Guid OrderItemID)
        {
            if (OrderItemID == Guid.Empty)
            {
                throw new InvalidOrderItemException(nameof(OrderItem.OrderItemID), OrderItemID);
            }
        }

        private static void ValidateOrderItemIsNull(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                throw new NullOrderItemException();
            }
        }

        private static void ValidateStorageOrderItem(OrderItem storageOrderItem, Guid orderItemID)
        {
            if (storageOrderItem == null)
            {
                throw new NotFoundOrderItemException(orderItemID);
            }
        }

        private static void Validate(params (dynamic rule, string parameter)[] validations)
        {
            var invalidOrderItemException = new InvalidOrderItemException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidOrderItemException.UpsertDataList(key: parameter, value: rule.Message);
                }
            }

            invalidOrderItemException.ThrowIfContainsErrors();
        }
    }

}

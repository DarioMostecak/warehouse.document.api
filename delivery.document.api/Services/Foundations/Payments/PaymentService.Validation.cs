// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Payments.Exceptions;
using delivery.document.api.Models.Payments;

namespace delivery.document.api.Services.Foundations.Payments
{
    public partial class PaymentService
    {
        private void ValidatePaymentOnCreate(Payment payment)
        {
            ValidatePaymentIsNull(payment);

            Validate(
                (rule: IsInvalid(payment.PaymentID), parameter: nameof(Payment.PaymentID)),
                (rule: IsInvalid(payment.OrderID), parameter: nameof(Payment.OrderID)),
                (rule: IsInvalid(payment.PaymentMethod), parameter: nameof(Payment.PaymentMethod)),
                (rule: IsInvalid(payment.PaymentDate), parameter: nameof(Payment.PaymentDate)),
                (rule: IsInvalid(payment.AmountPaid), parameter: nameof(Payment.AmountPaid)),
                (rule: IsInvalid(payment.PaymentStatus), parameter: nameof(Payment.PaymentStatus)),
                (rule: IsInvalid(payment.CreatedAt), parameter: nameof(Payment.CreatedAt)),
                (rule: IsInvalid(payment.UpdatedAt), parameter: nameof(Payment.UpdatedAt))
            );
        }

        private void ValidatePaymentOnModify(Payment payment)
        {
            ValidatePaymentIsNull(payment);

            Validate(
                (rule: IsInvalid(payment.PaymentID), parameter: nameof(Payment.PaymentID)),
                (rule: IsInvalid(payment.OrderID), parameter: nameof(Payment.OrderID)),
                (rule: IsInvalid(payment.PaymentMethod), parameter: nameof(Payment.PaymentMethod)),
                (rule: IsInvalid(payment.PaymentDate), parameter: nameof(Payment.PaymentDate)),
                (rule: IsInvalid(payment.AmountPaid), parameter: nameof(Payment.AmountPaid)),
                (rule: IsInvalid(payment.PaymentStatus), parameter: nameof(Payment.PaymentStatus)),
                (rule: IsInvalid(payment.CreatedAt), parameter: nameof(Payment.CreatedAt)),
                (rule: IsInvalid(payment.UpdatedAt), parameter: nameof(Payment.UpdatedAt)),
                (rule: IsSame(payment.CreatedAt, payment.UpdatedAt, nameof(Payment.UpdatedAt)),
                parameter: nameof(Payment.UpdatedAt))
            );
        }

        private static void ValidateAgainstStoragePaymentOnModify(
            Payment inputPayment, Payment storagePayment)
        {
            Validate(
                (rule: IsNotSame(inputPayment.PaymentID, storagePayment.PaymentID, nameof(Payment.PaymentID)),
                parameter: nameof(Payment.PaymentID)),

                (rule: IsNotSame(inputPayment.CreatedAt, storagePayment.CreatedAt, nameof(Payment.CreatedAt)),
                parameter: nameof(Payment.CreatedAt)),

                (rule: IsSame(inputPayment.UpdatedAt, storagePayment.UpdatedAt, nameof(Payment.UpdatedAt)),
                parameter: nameof(Payment.UpdatedAt))
            );
        }

        // New validation for Payment Amount
        private static dynamic IsInvalid(decimal amount) => new
        {
            Condition = amount <= 0,
            Message = "Amount must be greater than zero."
        };

        // Validation method for Payment Method
        private static dynamic IsInvalid(string paymentMethod) => new
        {
            Condition = string.IsNullOrWhiteSpace(paymentMethod) || paymentMethod.Length > 50,
            Message = "Payment method is required and must not exceed 50 characters."
        };

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "ID is required."
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

        private static void ValidatePaymentIsNull(Payment payment)
        {
            if (payment == null)
            {
                throw new NullPaymentException();
            }
        }

        private static void ValidatePaymentIdIsNull(Guid paymentID)
        {
            if (IsInvalid(paymentID))
            {
                var invalidPaymentException = new InvalidPaymentException(nameof(Payment.PaymentID), paymentID);
                throw invalidPaymentException;
            }
        }

        private static void ValidateStoragePayment(Payment storagePayment, Guid paymentID)
        {
            if (storagePayment == null) throw new NotFoundPaymentException(paymentID);
        }

        private static void Validate(params (dynamic rule, string parameter)[] validations)
        {
            var invalidPaymentException = new InvalidPaymentException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidPaymentException.UpsertDataList(key: parameter, value: rule.Message);
                }
            }

            invalidPaymentException.ThrowIfContainsErrors();
        }
    }

}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Invoices.Exceptions;
using delivery.document.api.Models.Invoices;

namespace delivery.document.api.Services.Foundations.Invoices
{
    public partial class InvoiceService
    {
        private void ValidateInvoiceOnCreate(Invoice invoice)
        {
            ValidateInvoiceIsNull(invoice);

            Validate(
                (rule: IsInvalid(invoice.InvoiceID), parameter: nameof(Invoice.InvoiceID)),
                (rule: IsInvalid(invoice.OrderID), parameter: nameof(Invoice.OrderID)),
                (rule: IsInvalid(invoice.InvoiceDate), parameter: nameof(Invoice.InvoiceDate)),
                (rule: IsInvalid(invoice.TotalAmount), parameter: nameof(Invoice.TotalAmount)),
                (rule: IsInvalid(invoice.PaymentDueDate), parameter: nameof(Invoice.PaymentDueDate)),
                (rule: IsInvalid(invoice.CreatedAt), parameter: nameof(Invoice.CreatedAt)),
                (rule: IsInvalid(invoice.UpdatedAt), parameter: nameof(Invoice.UpdatedAt))
            );
        }

        private void ValidateInvoiceOnModify(Invoice invoice)
        {
            ValidateInvoiceIsNull(invoice);

            Validate(
                (rule: IsInvalid(invoice.InvoiceID), parameter: nameof(Invoice.InvoiceID)),
                (rule: IsInvalid(invoice.OrderID), parameter: nameof(Invoice.OrderID)),
                (rule: IsInvalid(invoice.InvoiceDate), parameter: nameof(Invoice.InvoiceDate)),
                (rule: IsInvalid(invoice.TotalAmount), parameter: nameof(Invoice.TotalAmount)),
                (rule: IsInvalid(invoice.PaymentDueDate), parameter: nameof(Invoice.PaymentDueDate)),
                (rule: IsInvalid(invoice.CreatedAt), parameter: nameof(Invoice.CreatedAt)),
                (rule: IsInvalid(invoice.UpdatedAt), parameter: nameof(Invoice.UpdatedAt)),
                (rule: IsSame(invoice.CreatedAt, invoice.UpdatedAt, nameof(Invoice.UpdatedAt)),
                parameter: nameof(Invoice.UpdatedAt))
            );
        }

        private static void ValidateAgainstStorageInvoiceOnModify(
            Invoice inputInvoice, Invoice storageInvoice)
        {
            Validate(
                (rule: IsNotSame(inputInvoice.InvoiceID, storageInvoice.InvoiceID, nameof(Invoice.InvoiceID)),
                parameter: nameof(Invoice.InvoiceID)),

                (rule: IsNotSame(inputInvoice.CreatedAt, storageInvoice.CreatedAt, nameof(Invoice.CreatedAt)),
                parameter: nameof(Invoice.CreatedAt)),

                (rule: IsSame(inputInvoice.UpdatedAt, storageInvoice.UpdatedAt, nameof(Invoice.UpdatedAt)),
                parameter: nameof(Invoice.UpdatedAt))
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

        private static dynamic IsInvalid(decimal amount) => new
        {
            Condition = amount < 0,
            Message = "Total amount cannot be smaller than 0."
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

        private static void ValidateInvoiceIsNull(Invoice invoice)
        {
            if (invoice == null)
            {
                throw new NullInvoiceException();
            }
        }

        private static void ValidateInvoiceIdIsNull(Guid invoiceID)
        {
            if (IsInvalid(invoiceID))
            {
                var invalidInvoiceException = new InvalidInvoiceException(nameof(Invoice.InvoiceID), invoiceID);
                throw invalidInvoiceException;
            }
        }

        private static void ValidateStorageInvoice(Invoice storageInvoice, Guid invoiceID)
        {
            if (storageInvoice is null) throw new NotFoundInvoiceException(invoiceID);
        }

        private static void Validate(params (dynamic rule, string parameter)[] validations)
        {
            var invalidInvoiceException = new InvalidInvoiceException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidInvoiceException.UpsertDataList(key: parameter, value: rule.Message);
                }
            }

            invalidInvoiceException.ThrowIfContainsErrors();
        }
    }

}

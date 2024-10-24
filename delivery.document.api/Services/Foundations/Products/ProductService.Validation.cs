// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------


using delivery.document.api.Models.Products.Exceptions;
using delivery.document.api.Models.Products;

namespace delivery.document.api.Services.Foundations.Products
{
    public partial class ProductService
    {
        private void ValidateProductOnCreate(Product product)
        {
            ValidateProductIsNull(product);

            Validate(
                (rule: IsInvalid(product.ProductID), parameter: nameof(Product.ProductID)),
                (rule: IsInvalid(product.ProductName), parameter: nameof(Product.ProductName)),
                (rule: IsInvalid(product.SKU), parameter: nameof(Product.SKU)),
                (rule: IsInvalid(product.Description), parameter: nameof(Product.Description)),
                (rule: IsInvalid(product.Price), parameter: nameof(Product.Price)),
                (rule: IsInvalid(product.Weight), parameter: nameof(Product.Weight)),
                (rule: IsInvalid(product.Category), parameter: nameof(Product.Category)),
                (rule: IsInvalid(product.Stock), parameter: nameof(Product.Stock)),
                (rule: IsInvalid(product.CreatedAt), parameter: nameof(Product.CreatedAt)),
                (rule: IsInvalid(product.UpdatedAt), parameter: nameof(Product.UpdatedAt))
            );
        }

        private void ValidateProductOnModify(Product product)
        {
            ValidateProductIsNull(product);

            Validate(
                (rule: IsInvalid(product.ProductID), parameter: nameof(Product.ProductID)),
                (rule: IsInvalid(product.ProductName), parameter: nameof(Product.ProductName)),
                (rule: IsInvalid(product.SKU), parameter: nameof(Product.SKU)),
                (rule: IsInvalid(product.Description), parameter: nameof(Product.Description)),
                (rule: IsInvalid(product.Price), parameter: nameof(Product.Price)),
                (rule: IsInvalid(product.Weight), parameter: nameof(Product.Weight)),
                (rule: IsInvalid(product.Category), parameter: nameof(Product.Category)),
                (rule: IsInvalid(product.Stock), parameter: nameof(Product.Stock)),
                (rule: IsInvalid(product.CreatedAt), parameter: nameof(Product.CreatedAt)),
                (rule: IsInvalid(product.UpdatedAt), parameter: nameof(Product.UpdatedAt)),
                (rule: IsSame(product.CreatedAt, product.UpdatedAt, nameof(Product.UpdatedAt)),
                parameter: nameof(Product.UpdatedAt))
            );
        }

        private static void ValidateAgainstStorageProductOnModify(Product inputProduct, Product storageProduct)
        {
            Validate(
                (rule: IsNotSame(inputProduct.ProductID, storageProduct.ProductID, nameof(Product.ProductID)),
                parameter: nameof(Product.ProductID)),

                (rule: IsNotSame(inputProduct.CreatedAt, storageProduct.CreatedAt, nameof(Product.CreatedAt)),
                parameter: nameof(Product.CreatedAt)),

                (rule: IsSame(inputProduct.UpdatedAt, storageProduct.UpdatedAt, nameof(Product.UpdatedAt)),
                parameter: nameof(Product.UpdatedAt))
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

        private static dynamic IsInvalid(decimal price) => new
        {
            Condition = price <= 0,
            Message = "Must be a positive value."
        };

        private static dynamic IsInvalid(int stock) => new
        {
            Condition = stock < 0,
            Message = "Stock cannot be negative."
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

        private static void ValidateProductIsNull(Product product)
        {
            if (product == null)
            {
                throw new NullProductException();
            }
        }

        private static void ValidateProductIdIsNull(Guid productId)
        {
            if (IsInvalid(productId))
            {
                var invalidProductException = new InvalidProductException(nameof(Product.ProductID), productId);
                throw invalidProductException;
            }
        }

        private static void ValidateStorageProduct(Product storageProduct, Guid productId)
        {
            if (storageProduct is null) throw new NotFoundProductException(productId);
        }

        private static void Validate(params (dynamic rule, string parameter)[] validations)
        {
            var invalidProductException = new InvalidProductException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidProductException.UpsertDataList(key: parameter, value: rule.Message);
                }
            }

            invalidProductException.ThrowIfContainsErrors();
        }
    }

}

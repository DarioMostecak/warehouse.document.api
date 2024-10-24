// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Models.Products;

namespace delivery.document.api.Services.Foundations.Products
{
    public partial class ProductService : IProductService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public ProductService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Product> AddProductAsync(Product product) =>
        TryCatch(async () =>
        {
            ValidateProductOnCreate(product);

            return await this.storageBroker.InsertProductAsync(product);
        });

        public IQueryable<Product> RetrieveAllProducts() =>
        TryCatch(() => this.storageBroker.SelectAllProducts());

        public ValueTask<Product> RetrieveProductByIdAsync(Guid productId) =>
        TryCatch(async () =>
        {
            ValidateProductIdIsNull(productId);
            Product maybeProduct = await this.storageBroker.SelectProductByIdAsync(productId);
            ValidateStorageProduct(maybeProduct, productId);

            return maybeProduct;
        });

        public ValueTask<Product> ModifyProductAsync(Product product) =>
        TryCatch(async () =>
        {
            ValidateProductOnModify(product);
            Product maybeProduct = await this.storageBroker.SelectProductByIdAsync(product.ProductID);

            ValidateStorageProduct(maybeProduct, product.ProductID);
            ValidateAgainstStorageProductOnModify(inputProduct: product, storageProduct: maybeProduct);

            var updatedProduct = await this.storageBroker.UpdateProductAsync(product);

            return updatedProduct;
        });

        public ValueTask<Product> RemoveProductByIdAsync(Guid productId) =>
        TryCatch(async () =>
        {
            ValidateProductIdIsNull(productId);
            Product maybeProduct = await this.storageBroker.SelectProductByIdAsync(productId);
            ValidateStorageProduct(maybeProduct, productId);

            var deletedProduct = await this.storageBroker.DeleteProductAsync(maybeProduct);

            return deletedProduct;
        });
    }
}

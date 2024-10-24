// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Products;
using MongoDB.Driver;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        private IMongoCollection<Product> productCollection;

        public async ValueTask<Product> InsertProductAsync(Product product)
        {
            this.productCollection =
                this.db.GetCollection<Product>(GetCollectionName<Product>());

            await this.productCollection.InsertOneAsync(product);
            return product;
        }

        public IQueryable<Product> SelectAllProducts()
        {
            this.productCollection =
                this.db.GetCollection<Product>(GetCollectionName<Product>());

            return this.productCollection.AsQueryable();
        }

        public async ValueTask<Product> SelectProductByIdAsync(Guid productId)
        {
            this.productCollection =
                this.db.GetCollection<Product>(GetCollectionName<Product>());

            var product = await this.productCollection
                .Find(prod => prod.ProductID == productId)
                .FirstOrDefaultAsync();

            return product;
        }

        public async ValueTask<Product> UpdateProductAsync(Product product)
        {
            this.productCollection =
                this.db.GetCollection<Product>(GetCollectionName<Product>());

            await this.productCollection
                .ReplaceOneAsync(prod => prod.ProductID == product.ProductID, product);

            return product;
        }

        public async ValueTask<Product> DeleteProductAsync(Product product)
        {
            this.productCollection =
                this.db.GetCollection<Product>(GetCollectionName<Product>());

            await this.productCollection
                .DeleteOneAsync(prod => prod.ProductID == product.ProductID);

            return product;
        }
    }
}

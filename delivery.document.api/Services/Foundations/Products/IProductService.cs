// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Products;

namespace delivery.document.api.Services.Foundations.Products
{
    public interface IProductService
    {
        ValueTask<Product> AddProductAsync(Product product);
        IQueryable<Product> RetrieveAllProducts();
        ValueTask<Product> RetrieveProductByIdAsync(Guid productId);
        ValueTask<Product> ModifyProductAsync(Product product);
        ValueTask<Product> RemoveProductByIdAsync(Guid productId);
    }
}
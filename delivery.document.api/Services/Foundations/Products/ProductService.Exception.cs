// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Products.Exceptions;
using delivery.document.api.Models.Products;
using MongoDB.Driver;

namespace delivery.document.api.Services.Foundations.Products
{
    public partial class ProductService
    {
        private delegate ValueTask<Product> ReturnProductFunction();
        private delegate IQueryable<Product> ReturningQueryableProductsFunction();

        private async ValueTask<Product> TryCatch(
            ReturnProductFunction returnProductFunction)
        {
            try
            {
                return await returnProductFunction();
            }
            catch (NullProductException nullProductException)
            {
                throw CreateAndLogValidationException(nullProductException);
            }
            catch (InvalidProductException invalidProductException)
            {
                throw CreateAndLogValidationException(invalidProductException);
            }
            catch (NotFoundProductException notFoundProductException)
            {
                throw CreateAndLogValidationException(notFoundProductException);
            }
            catch (MongoWriteException mongoDuplicateKeyException)
            {
                var alreadyExistsProductException =
                    new AlreadyExistsProductExceptions(mongoDuplicateKeyException);

                throw CreateAndLogValidationException(alreadyExistsProductException);
            }
            catch (MongoException mongoException)
            {
                var failedProductServiceException =
                    new FailedProductServiceException(mongoException);

                throw CreateAndLogDependencyException(failedProductServiceException);
            }
            catch (Exception exception)
            {
                var failedProductServiceException =
                    new FailedProductServiceException(exception);

                throw CreateAndLogServiceException(failedProductServiceException);
            }
        }

        private IQueryable<Product> TryCatch(
            ReturningQueryableProductsFunction returningQueryableProductsFunction)
        {
            try
            {
                return returningQueryableProductsFunction();
            }
            catch (MongoException mongoException)
            {
                throw CreateAndLogDependencyException(mongoException);
            }
            catch (Exception exception)
            {
                var failedProductServiceException =
                    new FailedProductServiceException(exception);

                throw CreateAndLogServiceException(failedProductServiceException);
            }
        }

        private ProductValidationException CreateAndLogValidationException(Exception exception)
        {
            var productValidationException = new ProductValidationException(exception, exception.Data);
            this.loggingBroker.LogError(productValidationException);

            return productValidationException;
        }

        private ProductDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var productDependencyException = new ProductDependencyException(exception);
            this.loggingBroker.LogError(productDependencyException);

            return productDependencyException;
        }

        private ProductServiceException CreateAndLogServiceException(Exception exception)
        {
            var productServiceException = new ProductServiceException(exception);
            this.loggingBroker.LogError(productServiceException);

            return productServiceException;
        }
    }

}

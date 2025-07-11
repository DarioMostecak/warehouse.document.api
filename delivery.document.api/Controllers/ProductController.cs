// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Products.Exceptions;
using delivery.document.api.Models.Products;
using delivery.document.api.Services.Foundations.Products;
using Microsoft.AspNetCore.Mvc;

namespace delivery.document.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                IQueryable<Product> products = this.productService.RetrieveAllProducts();
                return Ok(products);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException);
            }
        }

        // GET: api/Product/{productId}
        [HttpGet("{productId}")]
        public async ValueTask<IActionResult> GetProductByIdAsync(Guid productId)
        {
            try
            {
                Product product = await this.productService.RetrieveProductByIdAsync(productId);
                return Ok(product);
            }
            catch (ProductValidationException productValidationException)
               when (productValidationException.InnerException is NotFoundProductException)
            {
                return NotFound(productValidationException.InnerException);
            }
            catch (ProductValidationException productValidationException)
            {
                return BadRequest(productValidationException);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException);
            }
        }

        // POST: api/Product
        [HttpPost]
        public async ValueTask<IActionResult> PostProductAsync([FromBody] Product product)
        {
            try
            {
                Product createdProduct = await this.productService.AddProductAsync(product);
                return Created(createdProduct);
            }
            catch (ProductValidationException productValidationException)
              when (productValidationException.InnerException is AlreadyExistsProductException)
            {
                return Conflict(productValidationException.InnerException);
            }
            catch (ProductValidationException productValidationException)
            {
                return BadRequest(productValidationException);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException);
            }
        }

        // PUT: api/Product
        [HttpPut]
        public async ValueTask<IActionResult> PutProductAsync([FromBody] Product product)
        {
            try
            {
                Product updatedProduct = await this.productService.ModifyProductAsync(product);
                return Ok(updatedProduct);
            }
            catch (ProductValidationException productValidationException)
               when (productValidationException.InnerException is NotFoundProductException)
            {
                return NotFound(productValidationException.InnerException);
            }
            catch (ProductValidationException productValidationException)
            {
                return BadRequest(productValidationException);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException);
            }
        }

        // DELETE: api/Product/{productId}
        [HttpDelete("{productId}")]
        public async ValueTask<IActionResult> DeleteProductAsync(Guid productId)
        {
            try
            {
                Product deletedProduct = await this.productService.RemoveProductByIdAsync(productId);
                return Ok(deletedProduct);
            }
            catch (ProductValidationException productValidationException)
               when (productValidationException.InnerException is NotFoundProductException)
            {
                return NotFound(productValidationException.InnerException);
            }
            catch (ProductValidationException productValidationException)
            {
                return BadRequest(productValidationException);
            }
            catch (ProductDependencyException productDependencyException)
            {
                return InternalServerError(productDependencyException);
            }
            catch (ProductServiceException productServiceException)
            {
                return InternalServerError(productServiceException);
            }
        }
    }
}

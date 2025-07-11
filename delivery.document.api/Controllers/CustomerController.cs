// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Customers.Exceptions;
using delivery.document.api.Models.Customers;
using delivery.document.api.Services.Foundations.Customers;
using Microsoft.AspNetCore.Mvc;

namespace delivery.document.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                IQueryable<Customer> customers = this.customerService.RetrieveAllCustomers();
                return Ok(customers);
            }
            catch (CustomerDependencyException customerDependencyException)
            {
                return InternalServerError(customerDependencyException);
            }
            catch (CustomerServiceException customerServiceException)
            {
                return InternalServerError(customerServiceException);
            }
        }

        // GET: api/Customer/{customerId}
        [HttpGet("{customerId}")]
        public async ValueTask<IActionResult> GetCustomerByIdAsync(Guid customerId)
        {
            try
            {
                Customer customer = await this.customerService.RetrieveCustomerByIdAsync(customerId);
                return Ok(customer);
            }
            catch (CustomerValidationException customerValidationException)
               when (customerValidationException.InnerException is NotFoundCustomerException)
            {
                return NotFound(customerValidationException.InnerException);
            }
            catch (CustomerValidationException customerValidationException)
            {
                return BadRequest(customerValidationException);
            }
            catch (CustomerDependencyException customerDependencyException)
            {
                return InternalServerError(customerDependencyException);
            }
            catch (CustomerServiceException customerServiceException)
            {
                return InternalServerError(customerServiceException);
            }
        }

        // POST: api/Customer
        [HttpPost]
        public async ValueTask<IActionResult> PostCustomerAsync([FromBody] Customer customer)
        {
            try
            {
                Customer createdCustomer = await this.customerService.AddCustomerAsync(customer);
                return Created(createdCustomer);
            }
            catch (CustomerValidationException customerValidationException)
              when (customerValidationException.InnerException is AlreadyExistsCustomerException)
            {
                return Conflict(customerValidationException.InnerException);
            }
            catch (CustomerValidationException customerValidationException)
            {
                return BadRequest(customerValidationException);
            }
            catch (CustomerDependencyException customerDependencyException)
            {
                return InternalServerError(customerDependencyException);
            }
            catch (CustomerServiceException customerServiceException)
            {
                return InternalServerError(customerServiceException);
            }
        }

        // PUT: api/Customer
        [HttpPut]
        public async ValueTask<IActionResult> PutCustomerAsync([FromBody] Customer customer)
        {
            try
            {
                Customer updatedCustomer = await this.customerService.ModifyCustomerAsync(customer);
                return Ok(updatedCustomer);
            }
            catch (CustomerValidationException customerValidationException)
               when (customerValidationException.InnerException is NotFoundCustomerException)
            {
                return NotFound(customerValidationException.InnerException);
            }
            catch (CustomerValidationException customerValidationException)
            {
                return BadRequest(customerValidationException);
            }
            catch (CustomerDependencyException customerDependencyException)
            {
                return InternalServerError(customerDependencyException);
            }
            catch (CustomerServiceException customerServiceException)
            {
                return InternalServerError(customerServiceException);
            }
        }

        // DELETE: api/Customer/{customerId}
        [HttpDelete("{customerId}")]
        public async ValueTask<IActionResult> DeleteCustomerAsync(Guid customerId)
        {
            try
            {
                Customer deletedCustomer = await this.customerService.RemoveCustomerByIdAsync(customerId);
                return Ok(deletedCustomer);
            }
            catch (CustomerValidationException customerValidationException)
               when (customerValidationException.InnerException is NotFoundCustomerException)
            {
                return NotFound(customerValidationException.InnerException);
            }
            catch (CustomerValidationException customerValidationException)
            {
                return BadRequest(customerValidationException);
            }
            catch (CustomerDependencyException customerDependencyException)
            {
                return InternalServerError(customerDependencyException);
            }
            catch (CustomerServiceException customerServiceException)
            {
                return InternalServerError(customerServiceException);
            }
        }
    }

}

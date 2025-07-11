// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Invoices.Exceptions;
using delivery.document.api.Models.Invoices;
using delivery.document.api.Services.Foundations.Invoices;
using Microsoft.AspNetCore.Mvc;

namespace delivery.document.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        // GET: api/Invoice
        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            try
            {
                IQueryable<Invoice> invoices = this.invoiceService.RetrieveAllInvoices();
                return Ok(invoices);
            }
            catch (InvoiceDependencyException invoiceDependencyException)
            {
                return InternalServerError(invoiceDependencyException);
            }
            catch (InvoiceServiceException invoiceServiceException)
            {
                return InternalServerError(invoiceServiceException);
            }
        }

        // GET: api/Invoice/{invoiceId}
        [HttpGet("{invoiceId}")]
        public async ValueTask<IActionResult> GetInvoiceByIdAsync(Guid invoiceId)
        {
            try
            {
                Invoice invoice = await this.invoiceService.RetrieveInvoiceByIdAsync(invoiceId);
                return Ok(invoice);
            }
            catch (InvoiceValidationException invoiceValidationException)
               when (invoiceValidationException.InnerException is NotFoundInvoiceException)
            {
                return NotFound(invoiceValidationException.InnerException);
            }
            catch (InvoiceValidationException invoiceValidationException)
            {
                return BadRequest(invoiceValidationException);
            }
            catch (InvoiceDependencyException invoiceDependencyException)
            {
                return InternalServerError(invoiceDependencyException);
            }
            catch (InvoiceServiceException invoiceServiceException)
            {
                return InternalServerError(invoiceServiceException);
            }
        }

        // POST: api/Invoice
        [HttpPost]
        public async ValueTask<IActionResult> PostInvoiceAsync([FromBody] Invoice invoice)
        {
            try
            {
                Invoice createdInvoice = await this.invoiceService.AddInvoiceAsync(invoice);
                return Created(createdInvoice);
            }
            catch (InvoiceValidationException invoiceValidationException)
              when (invoiceValidationException.InnerException is AlreadyExistsInvoiceException)
            {
                return Conflict(invoiceValidationException.InnerException);
            }
            catch (InvoiceValidationException invoiceValidationException)
            {
                return BadRequest(invoiceValidationException);
            }
            catch (InvoiceDependencyException invoiceDependencyException)
            {
                return InternalServerError(invoiceDependencyException);
            }
            catch (InvoiceServiceException invoiceServiceException)
            {
                return InternalServerError(invoiceServiceException);
            }
        }

        // PUT: api/Invoice
        [HttpPut]
        public async ValueTask<IActionResult> PutInvoiceAsync([FromBody] Invoice invoice)
        {
            try
            {
                Invoice updatedInvoice = await this.invoiceService.ModifyInvoiceAsync(invoice);
                return Ok(updatedInvoice);
            }
            catch (InvoiceValidationException invoiceValidationException)
               when (invoiceValidationException.InnerException is NotFoundInvoiceException)
            {
                return NotFound(invoiceValidationException.InnerException);
            }
            catch (InvoiceValidationException invoiceValidationException)
            {
                return BadRequest(invoiceValidationException);
            }
            catch (InvoiceDependencyException invoiceDependencyException)
            {
                return InternalServerError(invoiceDependencyException);
            }
            catch (InvoiceServiceException invoiceServiceException)
            {
                return InternalServerError(invoiceServiceException);
            }
        }

        // DELETE: api/Invoice/{invoiceId}
        [HttpDelete("{invoiceId}")]
        public async ValueTask<IActionResult> DeleteInvoiceAsync(Guid invoiceId)
        {
            try
            {
                Invoice deletedInvoice = await this.invoiceService.RemoveInvoiceByIdAsync(invoiceId);
                return Ok(deletedInvoice);
            }
            catch (InvoiceValidationException invoiceValidationException)
               when (invoiceValidationException.InnerException is NotFoundInvoiceException)
            {
                return NotFound(invoiceValidationException.InnerException);
            }
            catch (InvoiceValidationException invoiceValidationException)
            {
                return BadRequest(invoiceValidationException);
            }
            catch (InvoiceDependencyException invoiceDependencyException)
            {
                return InternalServerError(invoiceDependencyException);
            }
            catch (InvoiceServiceException invoiceServiceException)
            {
                return InternalServerError(invoiceServiceException);
            }
        }
    }

}

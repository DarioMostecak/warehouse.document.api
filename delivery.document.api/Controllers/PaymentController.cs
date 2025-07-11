// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Payments.Exceptions;
using delivery.document.api.Models.Payments;
using delivery.document.api.Services.Foundations.Payments;
using Microsoft.AspNetCore.Mvc;

namespace delivery.document.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : BaseController
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        // GET: api/Payment
        [HttpGet]
        public IActionResult GetAllPayments()
        {
            try
            {
                IQueryable<Payment> payments = this.paymentService.RetrieveAllPayments();
                return Ok(payments);
            }
            catch (PaymentDependencyException paymentDependencyException)
            {
                return InternalServerError(paymentDependencyException);
            }
            catch (PaymentServiceException paymentServiceException)
            {
                return InternalServerError(paymentServiceException);
            }
        }

        // GET: api/Payment/{paymentId}
        [HttpGet("{paymentId}")]
        public async ValueTask<IActionResult> GetPaymentByIdAsync(Guid paymentId)
        {
            try
            {
                Payment payment = await this.paymentService.RetrievePaymentByIdAsync(paymentId);
                return Ok(payment);
            }
            catch (PaymentValidationException paymentValidationException)
               when (paymentValidationException.InnerException is NotFoundPaymentException)
            {
                return NotFound(paymentValidationException.InnerException);
            }
            catch (PaymentValidationException paymentValidationException)
            {
                return BadRequest(paymentValidationException);
            }
            catch (PaymentDependencyException paymentDependencyException)
            {
                return InternalServerError(paymentDependencyException);
            }
            catch (PaymentServiceException paymentServiceException)
            {
                return InternalServerError(paymentServiceException);
            }
        }

        // POST: api/Payment
        [HttpPost]
        public async ValueTask<IActionResult> PostPaymentAsync([FromBody] Payment payment)
        {
            try
            {
                Payment createdPayment = await this.paymentService.AddPaymentAsync(payment);
                return Created(createdPayment);
            }
            catch (PaymentValidationException paymentValidationException)
              when (paymentValidationException.InnerException is AlreadyExistsPaymentException)
            {
                return Conflict(paymentValidationException.InnerException);
            }
            catch (PaymentValidationException paymentValidationException)
            {
                return BadRequest(paymentValidationException);
            }
            catch (PaymentDependencyException paymentDependencyException)
            {
                return InternalServerError(paymentDependencyException);
            }
            catch (PaymentServiceException paymentServiceException)
            {
                return InternalServerError(paymentServiceException);
            }
        }

        // PUT: api/Payment
        [HttpPut]
        public async ValueTask<IActionResult> PutPaymentAsync([FromBody] Payment payment)
        {
            try
            {
                Payment updatedPayment = await this.paymentService.ModifyPaymentAsync(payment);
                return Ok(updatedPayment);
            }
            catch (PaymentValidationException paymentValidationException)
               when (paymentValidationException.InnerException is NotFoundPaymentException)
            {
                return NotFound(paymentValidationException.InnerException);
            }
            catch (PaymentValidationException paymentValidationException)
            {
                return BadRequest(paymentValidationException);
            }
            catch (PaymentDependencyException paymentDependencyException)
            {
                return InternalServerError(paymentDependencyException);
            }
            catch (PaymentServiceException paymentServiceException)
            {
                return InternalServerError(paymentServiceException);
            }
        }

        // DELETE: api/Payment/{paymentId}
        [HttpDelete("{paymentId}")]
        public async ValueTask<IActionResult> DeletePaymentAsync(Guid paymentId)
        {
            try
            {
                Payment deletedPayment = await this.paymentService.RemovePaymentByIdAsync(paymentId);
                return Ok(deletedPayment);
            }
            catch (PaymentValidationException paymentValidationException)
               when (paymentValidationException.InnerException is NotFoundPaymentException)
            {
                return NotFound(paymentValidationException.InnerException);
            }
            catch (PaymentValidationException paymentValidationException)
            {
                return BadRequest(paymentValidationException);
            }
            catch (PaymentDependencyException paymentDependencyException)
            {
                return InternalServerError(paymentDependencyException);
            }
            catch (PaymentServiceException paymentServiceException)
            {
                return InternalServerError(paymentServiceException);
            }
        }
    }
}

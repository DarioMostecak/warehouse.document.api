// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.DeliveryDocuments.Exceptions;
using delivery.document.api.Models.DeliveryDocuments;
using delivery.document.api.Services.Foundations.DeliveryDocuments;
using Microsoft.AspNetCore.Mvc;

namespace delivery.document.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryDocumentController : BaseController
    {
        private readonly IDeliveryDocumentService deliveryDocumentService;

        public DeliveryDocumentController(IDeliveryDocumentService deliveryDocumentService)
        {
            this.deliveryDocumentService = deliveryDocumentService;
        }

        // GET: api/DeliveryDocument
        [HttpGet]
        public IActionResult GetAllDeliveryDocuments()
        {
            try
            {
                IQueryable<DeliveryDocument> deliveryDocuments = this.deliveryDocumentService.RetrieveAllDeliveryDocuments();
                return Ok(deliveryDocuments);
            }
            catch (DeliveryDocumentDependencyException deliveryDocumentDependencyException)
            {
                return InternalServerError(deliveryDocumentDependencyException);
            }
            catch (DeliveryDocumentServiceException deliveryDocumentServiceException)
            {
                return InternalServerError(deliveryDocumentServiceException);
            }
        }

        // GET: api/DeliveryDocument/{deliveryDocumentId}
        [HttpGet("{deliveryDocumentId}")]
        public async ValueTask<IActionResult> GetDeliveryDocumentByIdAsync(Guid deliveryDocumentId)
        {
            try
            {
                DeliveryDocument deliveryDocument = await this.deliveryDocumentService.RetrieveDeliveryDocumentByIdAsync(deliveryDocumentId);
                return Ok(deliveryDocument);
            }
            catch (DeliveryDocumentValidationException deliveryDocumentValidationException)
               when (deliveryDocumentValidationException.InnerException is NotFoundDeliveryDocumentException)
            {
                return NotFound(deliveryDocumentValidationException.InnerException);
            }
            catch (DeliveryDocumentValidationException deliveryDocumentValidationException)
            {
                return BadRequest(deliveryDocumentValidationException);
            }
            catch (DeliveryDocumentDependencyException deliveryDocumentDependencyException)
            {
                return InternalServerError(deliveryDocumentDependencyException);
            }
            catch (DeliveryDocumentServiceException deliveryDocumentServiceException)
            {
                return InternalServerError(deliveryDocumentServiceException);
            }
        }

        // POST: api/DeliveryDocument
        [HttpPost]
        public async ValueTask<IActionResult> PostDeliveryDocumentAsync([FromBody] DeliveryDocument deliveryDocument)
        {
            try
            {
                DeliveryDocument createdDeliveryDocument = await this.deliveryDocumentService.AddDeliveryDocumentAsync(deliveryDocument);
                return Created(createdDeliveryDocument);
            }
            catch (DeliveryDocumentValidationException deliveryDocumentValidationException)
              when (deliveryDocumentValidationException.InnerException is AlreadyExistsDeliveryDocumentException)
            {
                return Conflict(deliveryDocumentValidationException.InnerException);
            }
            catch (DeliveryDocumentValidationException deliveryDocumentValidationException)
            {
                return BadRequest(deliveryDocumentValidationException);
            }
            catch (DeliveryDocumentDependencyException deliveryDocumentDependencyException)
            {
                return InternalServerError(deliveryDocumentDependencyException);
            }
            catch (DeliveryDocumentServiceException deliveryDocumentServiceException)
            {
                return InternalServerError(deliveryDocumentServiceException);
            }
        }

        // PUT: api/DeliveryDocument
        [HttpPut]
        public async ValueTask<IActionResult> PutDeliveryDocumentAsync([FromBody] DeliveryDocument deliveryDocument)
        {
            try
            {
                DeliveryDocument updatedDeliveryDocument = await this.deliveryDocumentService.ModifyDeliveryDocumentAsync(deliveryDocument);
                return Ok(updatedDeliveryDocument);
            }
            catch (DeliveryDocumentValidationException deliveryDocumentValidationException)
               when (deliveryDocumentValidationException.InnerException is NotFoundDeliveryDocumentException)
            {
                return NotFound(deliveryDocumentValidationException.InnerException);
            }
            catch (DeliveryDocumentValidationException deliveryDocumentValidationException)
            {
                return BadRequest(deliveryDocumentValidationException);
            }
            catch (DeliveryDocumentDependencyException deliveryDocumentDependencyException)
            {
                return InternalServerError(deliveryDocumentDependencyException);
            }
            catch (DeliveryDocumentServiceException deliveryDocumentServiceException)
            {
                return InternalServerError(deliveryDocumentServiceException);
            }
        }

        // DELETE: api/DeliveryDocument/{deliveryDocumentId}
        [HttpDelete("{deliveryDocumentId}")]
        public async ValueTask<IActionResult> DeleteDeliveryDocumentAsync(Guid deliveryDocumentId)
        {
            try
            {
                DeliveryDocument deletedDeliveryDocument = await this.deliveryDocumentService.RemoveDeliveryDocumentByIdAsync(deliveryDocumentId);
                return Ok(deletedDeliveryDocument);
            }
            catch (DeliveryDocumentValidationException deliveryDocumentValidationException)
               when (deliveryDocumentValidationException.InnerException is NotFoundDeliveryDocumentException)
            {
                return NotFound(deliveryDocumentValidationException.InnerException);
            }
            catch (DeliveryDocumentValidationException deliveryDocumentValidationException)
            {
                return BadRequest(deliveryDocumentValidationException);
            }
            catch (DeliveryDocumentDependencyException deliveryDocumentDependencyException)
            {
                return InternalServerError(deliveryDocumentDependencyException);
            }
            catch (DeliveryDocumentServiceException deliveryDocumentServiceException)
            {
                return InternalServerError(deliveryDocumentServiceException);
            }
        }
    }

}

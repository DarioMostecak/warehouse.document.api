// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Shipments.Exceptions;
using delivery.document.api.Models.Shipments;
using delivery.document.api.Services.Foundations.Shipments;
using Microsoft.AspNetCore.Mvc;

namespace delivery.document.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentController : BaseController
    {
        private readonly IShipmentService shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            this.shipmentService = shipmentService;
        }

        // GET: api/Shipment
        [HttpGet]
        public IActionResult GetAllShipments()
        {
            try
            {
                IQueryable<Shipment> shipments = this.shipmentService.RetrieveAllShipments();
                return Ok(shipments);
            }
            catch (ShipmentDependencyException shipmentDependencyException)
            {
                return InternalServerError(shipmentDependencyException);
            }
            catch (ShipmentServiceException shipmentServiceException)
            {
                return InternalServerError(shipmentServiceException);
            }
        }

        // GET: api/Shipment/{shipmentId}
        [HttpGet("{shipmentId}")]
        public async ValueTask<IActionResult> GetShipmentByIdAsync(Guid shipmentId)
        {
            try
            {
                Shipment shipment = await this.shipmentService.RetrieveShipmentByIdAsync(shipmentId);
                return Ok(shipment);
            }
            catch (ShipmentValidationException shipmentValidationException)
               when (shipmentValidationException.InnerException is NotFoundShipmentException)
            {
                return NotFound(shipmentValidationException.InnerException);
            }
            catch (ShipmentValidationException shipmentValidationException)
            {
                return BadRequest(shipmentValidationException);
            }
            catch (ShipmentDependencyException shipmentDependencyException)
            {
                return InternalServerError(shipmentDependencyException);
            }
            catch (ShipmentServiceException shipmentServiceException)
            {
                return InternalServerError(shipmentServiceException);
            }
        }

        // POST: api/Shipment
        [HttpPost]
        public async ValueTask<IActionResult> PostShipmentAsync([FromBody] Shipment shipment)
        {
            try
            {
                Shipment createdShipment = await this.shipmentService.AddShipmentAsync(shipment);
                return Created(createdShipment);
            }
            catch (ShipmentValidationException shipmentValidationException)
              when (shipmentValidationException.InnerException is AlreadyExistsShipmentException)
            {
                return Conflict(shipmentValidationException.InnerException);
            }
            catch (ShipmentValidationException shipmentValidationException)
            {
                return BadRequest(shipmentValidationException);
            }
            catch (ShipmentDependencyException shipmentDependencyException)
            {
                return InternalServerError(shipmentDependencyException);
            }
            catch (ShipmentServiceException shipmentServiceException)
            {
                return InternalServerError(shipmentServiceException);
            }
        }

        // PUT: api/Shipment
        [HttpPut]
        public async ValueTask<IActionResult> PutShipmentAsync([FromBody] Shipment shipment)
        {
            try
            {
                Shipment updatedShipment = await this.shipmentService.ModifyShipmentAsync(shipment);
                return Ok(updatedShipment);
            }
            catch (ShipmentValidationException shipmentValidationException)
               when (shipmentValidationException.InnerException is NotFoundShipmentException)
            {
                return NotFound(shipmentValidationException.InnerException);
            }
            catch (ShipmentValidationException shipmentValidationException)
            {
                return BadRequest(shipmentValidationException);
            }
            catch (ShipmentDependencyException shipmentDependencyException)
            {
                return InternalServerError(shipmentDependencyException);
            }
            catch (ShipmentServiceException shipmentServiceException)
            {
                return InternalServerError(shipmentServiceException);
            }
        }

        // DELETE: api/Shipment/{shipmentId}
        [HttpDelete("{shipmentId}")]
        public async ValueTask<IActionResult> DeleteShipmentAsync(Guid shipmentId)
        {
            try
            {
                Shipment deletedShipment = await this.shipmentService.RemoveShipmentByIdAsync(shipmentId);
                return Ok(deletedShipment);
            }
            catch (ShipmentValidationException shipmentValidationException)
               when (shipmentValidationException.InnerException is NotFoundShipmentException)
            {
                return NotFound(shipmentValidationException.InnerException);
            }
            catch (ShipmentValidationException shipmentValidationException)
            {
                return BadRequest(shipmentValidationException);
            }
            catch (ShipmentDependencyException shipmentDependencyException)
            {
                return InternalServerError(shipmentDependencyException);
            }
            catch (ShipmentServiceException shipmentServiceException)
            {
                return InternalServerError(shipmentServiceException);
            }
        }
    }
}

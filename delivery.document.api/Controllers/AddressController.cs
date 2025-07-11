// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Addresses.Exceptions;
using delivery.document.api.Models.Addresses;
using delivery.document.api.Services.Foundations.Addresses;
using Microsoft.AspNetCore.Mvc;

namespace delivery.document.api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]    
    public class AddressController : BaseController
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        // GET: api/Address
        [HttpGet]
        public IActionResult GetAllAddresses()
        {
            try
            {
                IQueryable<Address> addresses = this.addressService.RetrieveAllAddresses();
                return Ok(addresses);
            }
            catch (AddressDependencyException addressDependencyException)
            {
                return InternalServerError(addressDependencyException);
            }
            catch (AddressServiceException addressServiceException)
            {
                return InternalServerError(addressServiceException);
            }
        }

        // GET: api/Address/{addressId}
        [HttpGet("{addressId}")]
        public async ValueTask<IActionResult> GetAddressByIdAsync(Guid addressId)
        {
            try
            {
                Address address = await this.addressService.RetrieveAddressByIdAsync(addressId);
                return Ok(address);
            }
            catch (AddressValidationException addressValidationException)
               when (addressValidationException.InnerException is NotFoundAddressException)
            {
                return NotFound(addressValidationException.InnerException);
            }
            catch (AddressValidationException addressValidationException)
            {
                return BadRequest(addressValidationException);
            }
            catch (AddressDependencyException addressDependencyException)
            {
                return InternalServerError(addressDependencyException);
            }
            catch (AddressServiceException addressServiceException)
            {
                return InternalServerError(addressServiceException);
            }
        }

        // POST: api/Address
        [HttpPost]
        public async ValueTask<IActionResult> PostAddressAsync([FromBody] Address address)
        {
            try
            {
                Address createdAddress = await this.addressService.AddAddressAsync(address);
                return Created(createdAddress);
            }
            catch (AddressValidationException addressValidationException)
              when (addressValidationException.InnerException is AlreadyExistsAddressException)
            {
                return Conflict(addressValidationException.InnerException);
            }
            catch (AddressValidationException addressValidationException)
            {
                return BadRequest(addressValidationException);
            }
            catch (AddressDependencyException addressDependencyException)
            {
                return InternalServerError(addressDependencyException);
            }
            catch (AddressServiceException addressServiceException)
            {
                return InternalServerError(addressServiceException);
            }
        }

        // PUT: api/Address
        [HttpPut]
        public async ValueTask<IActionResult> PutAddressAsync([FromBody] Address address)
        {
            try
            {
                Address updatedAddress = await this.addressService.ModifyAddressAsync(address);
                return Ok(updatedAddress);
            }
            catch (AddressValidationException addressValidationException)
               when (addressValidationException.InnerException is NotFoundAddressException)
            {
                return NotFound(addressValidationException.InnerException);
            }
            catch (AddressValidationException addressValidationException)
            {
                return BadRequest(addressValidationException);
            }
            catch (AddressDependencyException addressDependencyException)
            {
                return InternalServerError(addressDependencyException);
            }
            catch (AddressServiceException addressServiceException)
            {
                return InternalServerError(addressServiceException);
            }
        }

        // DELETE: api/Address/{addressId}
        [HttpDelete("{addressId}")]
        public async ValueTask<IActionResult> DeleteAddressAsync(Guid addressId)
        {
            try
            {
                Address deletedAddress = await this.addressService.RemoveAddressByIdAsync(addressId);
                return Ok(deletedAddress);
            }
            catch (AddressValidationException addressValidationException)
               when (addressValidationException.InnerException is NotFoundAddressException)
            {
                return NotFound(addressValidationException.InnerException);
            }
            catch (AddressValidationException addressValidationException)
            {
                return BadRequest(addressValidationException);
            }
            catch (AddressDependencyException addressDependencyException)
            {
                return InternalServerError(addressDependencyException);
            }
            catch (AddressServiceException addressServiceException)
            {
                return InternalServerError(addressServiceException);
            }
        }
    }

}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.OrderItems.Exceptions;
using delivery.document.api.Models.OrderItems;
using delivery.document.api.Services.Foundations.OrderItems;
using Microsoft.AspNetCore.Mvc;

namespace delivery.document.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : BaseController
    {
        private readonly IOrderItemService orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            this.orderItemService = orderItemService;
        }

        // GET: api/OrderItem
        [HttpGet]
        public IActionResult GetAllOrderItems()
        {
            try
            {
                IQueryable<OrderItem> orderItems = this.orderItemService.RetrieveAllOrderItems();
                return Ok(orderItems);
            }
            catch (OrderItemDependencyException orderItemDependencyException)
            {
                return InternalServerError(orderItemDependencyException);
            }
            catch (OrderItemServiceException orderItemServiceException)
            {
                return InternalServerError(orderItemServiceException);
            }
        }

        // GET: api/OrderItem/{orderItemId}
        [HttpGet("{orderItemId}")]
        public async ValueTask<IActionResult> GetOrderItemByIdAsync(Guid orderItemId)
        {
            try
            {
                OrderItem orderItem = await this.orderItemService.RetrieveOrderItemByIdAsync(orderItemId);
                return Ok(orderItem);
            }
            catch (OrderItemValidationException orderItemValidationException)
               when (orderItemValidationException.InnerException is NotFoundOrderItemException)
            {
                return NotFound(orderItemValidationException.InnerException);
            }
            catch (OrderItemValidationException orderItemValidationException)
            {
                return BadRequest(orderItemValidationException);
            }
            catch (OrderItemDependencyException orderItemDependencyException)
            {
                return InternalServerError(orderItemDependencyException);
            }
            catch (OrderItemServiceException orderItemServiceException)
            {
                return InternalServerError(orderItemServiceException);
            }
        }

        // POST: api/OrderItem
        [HttpPost]
        public async ValueTask<IActionResult> PostOrderItemAsync([FromBody] OrderItem orderItem)
        {
            try
            {
                OrderItem createdOrderItem = await this.orderItemService.AddOrderItemAsync(orderItem);
                return Created(createdOrderItem);
            }
            catch (OrderItemValidationException orderItemValidationException)
              when (orderItemValidationException.InnerException is AlreadyExistsOrderItemException)
            {
                return Conflict(orderItemValidationException.InnerException);
            }
            catch (OrderItemValidationException orderItemValidationException)
            {
                return BadRequest(orderItemValidationException);
            }
            catch (OrderItemDependencyException orderItemDependencyException)
            {
                return InternalServerError(orderItemDependencyException);
            }
            catch (OrderItemServiceException orderItemServiceException)
            {
                return InternalServerError(orderItemServiceException);
            }
        }

        // PUT: api/OrderItem
        [HttpPut]
        public async ValueTask<IActionResult> PutOrderItemAsync([FromBody] OrderItem orderItem)
        {
            try
            {
                OrderItem updatedOrderItem = await this.orderItemService.ModifyOrderItemAsync(orderItem);
                return Ok(updatedOrderItem);
            }
            catch (OrderItemValidationException orderItemValidationException)
               when (orderItemValidationException.InnerException is NotFoundOrderItemException)
            {
                return NotFound(orderItemValidationException.InnerException);
            }
            catch (OrderItemValidationException orderItemValidationException)
            {
                return BadRequest(orderItemValidationException);
            }
            catch (OrderItemDependencyException orderItemDependencyException)
            {
                return InternalServerError(orderItemDependencyException);
            }
            catch (OrderItemServiceException orderItemServiceException)
            {
                return InternalServerError(orderItemServiceException);
            }
        }

        // DELETE: api/OrderItem/{orderItemId}
        [HttpDelete("{orderItemId}")]
        public async ValueTask<IActionResult> DeleteOrderItemAsync(Guid orderItemId)
        {
            try
            {
                OrderItem deletedOrderItem = await this.orderItemService.RemoveOrderItemByIdAsync(orderItemId);
                return Ok(deletedOrderItem);
            }
            catch (OrderItemValidationException orderItemValidationException)
               when (orderItemValidationException.InnerException is NotFoundOrderItemException)
            {
                return NotFound(orderItemValidationException.InnerException);
            }
            catch (OrderItemValidationException orderItemValidationException)
            {
                return BadRequest(orderItemValidationException);
            }
            catch (OrderItemDependencyException orderItemDependencyException)
            {
                return InternalServerError(orderItemDependencyException);
            }
            catch (OrderItemServiceException orderItemServiceException)
            {
                return InternalServerError(orderItemServiceException);
            }
        }
    }
}


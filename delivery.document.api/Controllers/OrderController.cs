// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Orders.Exceptions;
using delivery.document.api.Models.Orders;
using delivery.document.api.Services.Foundations.Orders;
using Microsoft.AspNetCore.Mvc;

namespace delivery.document.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                IQueryable<Order> orders = this.orderService.RetrieveAllOrders();
                return Ok(orders);
            }
            catch (OrderDependencyException orderDependencyException)
            {
                return InternalServerError(orderDependencyException);
            }
            catch (OrderServiceException orderServiceException)
            {
                return InternalServerError(orderServiceException);
            }
        }

        // GET: api/Order/{orderId}
        [HttpGet("{orderId}")]
        public async ValueTask<IActionResult> GetOrderByIdAsync(Guid orderId)
        {
            try
            {
                Order order = await this.orderService.RetrieveOrderByIdAsync(orderId);
                return Ok(order);
            }
            catch (OrderValidationException orderValidationException)
               when (orderValidationException.InnerException is NotFoundOrderException)
            {
                return NotFound(orderValidationException.InnerException);
            }
            catch (OrderValidationException orderValidationException)
            {
                return BadRequest(orderValidationException);
            }
            catch (OrderDependencyException orderDependencyException)
            {
                return InternalServerError(orderDependencyException);
            }
            catch (OrderServiceException orderServiceException)
            {
                return InternalServerError(orderServiceException);
            }
        }

        // POST: api/Order
        [HttpPost]
        public async ValueTask<IActionResult> PostOrderAsync([FromBody] Order order)
        {
            try
            {
                Order createdOrder = await this.orderService.AddOrderAsync(order);
                return Created(createdOrder);
            }
            catch (OrderValidationException orderValidationException)
              when (orderValidationException.InnerException is AlreadyExistsOrderException)
            {
                return Conflict(orderValidationException.InnerException);
            }
            catch (OrderValidationException orderValidationException)
            {
                return BadRequest(orderValidationException);
            }
            catch (OrderDependencyException orderDependencyException)
            {
                return InternalServerError(orderDependencyException);
            }
            catch (OrderServiceException orderServiceException)
            {
                return InternalServerError(orderServiceException);
            }
        }

        // PUT: api/Order
        [HttpPut]
        public async ValueTask<IActionResult> PutOrderAsync([FromBody] Order order)
        {
            try
            {
                Order updatedOrder = await this.orderService.ModifyOrderAsync(order);
                return Ok(updatedOrder);
            }
            catch (OrderValidationException orderValidationException)
               when (orderValidationException.InnerException is NotFoundOrderException)
            {
                return NotFound(orderValidationException.InnerException);
            }
            catch (OrderValidationException orderValidationException)
            {
                return BadRequest(orderValidationException);
            }
            catch (OrderDependencyException orderDependencyException)
            {
                return InternalServerError(orderDependencyException);
            }
            catch (OrderServiceException orderServiceException)
            {
                return InternalServerError(orderServiceException);
            }
        }

        // DELETE: api/Order/{orderId}
        [HttpDelete("{orderId}")]
        public async ValueTask<IActionResult> DeleteOrderAsync(Guid orderId)
        {
            try
            {
                Order deletedOrder = await this.orderService.RemoveOrderByIdAsync(orderId);
                return Ok(deletedOrder);
            }
            catch (OrderValidationException orderValidationException)
               when (orderValidationException.InnerException is NotFoundOrderException)
            {
                return NotFound(orderValidationException.InnerException);
            }
            catch (OrderValidationException orderValidationException)
            {
                return BadRequest(orderValidationException);
            }
            catch (OrderDependencyException orderDependencyException)
            {
                return InternalServerError(orderDependencyException);
            }
            catch (OrderServiceException orderServiceException)
            {
                return InternalServerError(orderServiceException);
            }
        }
    }
}


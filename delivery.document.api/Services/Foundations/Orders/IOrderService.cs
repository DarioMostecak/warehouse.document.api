// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Orders;

namespace delivery.document.api.Services.Foundations.Orders
{
    public interface IOrderService
    {
        ValueTask<Order> AddOrderAsync(Order order);
        IQueryable<Order> RetrieveAllOrders();
        ValueTask<Order> RetrieveOrderByIdAsync(Guid orderId);
        ValueTask<Order> ModifyOrderAsync(Order order);
        ValueTask<Order> RemoveOrderByIdAsync(Guid orderId);
    }
}
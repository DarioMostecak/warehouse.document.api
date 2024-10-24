// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Orders;

namespace delivery.document.api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Order> InsertOrderAsync(Order order);
        IQueryable<Order> SelectAllOrders();
        ValueTask<Order> SelectOrderByIdAsync(Guid orderId);
        ValueTask<Order> UpdateOrderAsync(Order order);
        ValueTask<Order> DeleteOrderAsync(Order order);
    }
}

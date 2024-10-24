// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.OrderItems;

namespace delivery.document.api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<OrderItem> InsertOrderItemAsync(OrderItem orderItem);
        IQueryable<OrderItem> SelectAllOrderItems();
        ValueTask<OrderItem> SelectOrderItemByIdAsync(Guid orderItemId);
        ValueTask<OrderItem> UpdateOrderItemAsync(OrderItem orderItem);
        ValueTask<OrderItem> DeleteOrderItemAsync(OrderItem orderItem);
    }
}

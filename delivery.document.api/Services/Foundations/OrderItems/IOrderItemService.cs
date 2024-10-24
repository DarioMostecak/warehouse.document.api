// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.OrderItems;

namespace delivery.document.api.Services.Foundations.OrderItems
{
    public interface IOrderItemService
    {
        ValueTask<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        IQueryable<OrderItem> RetrieveAllOrderItems();
        ValueTask<OrderItem> RetrieveOrderItemByIdAsync(Guid orderItemId);
        ValueTask<OrderItem> ModifyOrderItemAsync(OrderItem orderItem);
        ValueTask<OrderItem> RemoveOrderItemByIdAsync(Guid orderItemId);
    }
}
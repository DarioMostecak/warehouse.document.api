// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Models.OrderItems;

namespace delivery.document.api.Services.Foundations.OrderItems
{
    public partial class OrderItemService : IOrderItemService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public OrderItemService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<OrderItem> AddOrderItemAsync(OrderItem orderItem) =>
        TryCatch(async () =>
        {
            ValidateOrderItemOnCreate(orderItem);

            return await this.storageBroker.InsertOrderItemAsync(orderItem);
        });

        public IQueryable<OrderItem> RetrieveAllOrderItems() =>
        TryCatch(() => this.storageBroker.SelectAllOrderItems());

        public ValueTask<OrderItem> RetrieveOrderItemByIdAsync(Guid orderItemId) =>
        TryCatch(async () =>
        {
            ValidateOrderItemIdIsNull(orderItemId);
            OrderItem maybeOrderItem = await this.storageBroker.SelectOrderItemByIdAsync(orderItemId);
            ValidateStorageOrderItem(maybeOrderItem, orderItemId);

            return maybeOrderItem;
        });

        public ValueTask<OrderItem> ModifyOrderItemAsync(OrderItem orderItem) =>
        TryCatch(async () =>
        {
            ValidateOrderItemOnModify(orderItem);
            OrderItem maybeOrderItem = await this.storageBroker.SelectOrderItemByIdAsync(orderItem.OrderItemID);

            ValidateStorageOrderItem(maybeOrderItem, orderItem.OrderItemID);
            ValidateAgainstStorageOrderItemOnModify(inputOrderItem: orderItem, storageOrderItem: maybeOrderItem);

            var updatedOrderItem = await this.storageBroker.UpdateOrderItemAsync(orderItem);

            return updatedOrderItem;
        });

        public ValueTask<OrderItem> RemoveOrderItemByIdAsync(Guid orderItemId) =>
        TryCatch(async () =>
        {
            ValidateOrderItemIdIsNull(orderItemId);
            OrderItem maybeOrderItem = await this.storageBroker.SelectOrderItemByIdAsync(orderItemId);
            ValidateStorageOrderItem(maybeOrderItem, orderItemId);

            var deletedOrderItem = await this.storageBroker.DeleteOrderItemAsync(maybeOrderItem);

            return deletedOrderItem;
        });

      
    }

}

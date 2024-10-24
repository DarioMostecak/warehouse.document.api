// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Models.Orders;

namespace delivery.document.api.Services.Foundations.Orders
{
    public partial class OrderService : IOrderService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public OrderService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Order> AddOrderAsync(Order order) =>
        TryCatch(async () =>
        {
            ValidateOrderOnCreate(order);

            return await this.storageBroker.InsertOrderAsync(order);
        });

        public IQueryable<Order> RetrieveAllOrders() =>
        TryCatch(() => this.storageBroker.SelectAllOrders());

        public ValueTask<Order> RetrieveOrderByIdAsync(Guid orderId) =>
        TryCatch(async () =>
        {
            ValidateOrderIdIsNull(orderId);
            Order maybeOrder = await this.storageBroker.SelectOrderByIdAsync(orderId);
            ValidateStorageOrder(maybeOrder, orderId);

            return maybeOrder;
        });

        public ValueTask<Order> ModifyOrderAsync(Order order) =>
        TryCatch(async () =>
        {
            ValidateOrderOnModify(order);
            Order maybeOrder = await this.storageBroker.SelectOrderByIdAsync(order.OrderID);

            ValidateStorageOrder(maybeOrder, order.OrderID);
            ValidateAgainstStorageOrderOnModify(inputOrder: order, storageOrder: maybeOrder);

            var updatedOrder = await this.storageBroker.UpdateOrderAsync(order);

            return updatedOrder;
        });

        public ValueTask<Order> RemoveOrderByIdAsync(Guid orderId) =>
        TryCatch(async () =>
        {
            ValidateOrderIdIsNull(orderId);
            Order maybeOrder = await this.storageBroker.SelectOrderByIdAsync(orderId);
            ValidateStorageOrder(maybeOrder, orderId);

            var deletedOrder = await this.storageBroker.DeleteOrderAsync(maybeOrder);

            return deletedOrder;
        });
    }

}

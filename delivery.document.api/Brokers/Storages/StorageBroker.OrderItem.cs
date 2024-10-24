// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.OrderItems;
using MongoDB.Driver;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        private IMongoCollection<OrderItem> orderItemCollection;

        public async ValueTask<OrderItem> InsertOrderItemAsync(OrderItem orderItem)
        {
            this.orderItemCollection =
                this.db.GetCollection<OrderItem>(GetCollectionName<OrderItem>());

            await this.orderItemCollection.InsertOneAsync(orderItem);
            return orderItem;
        }

        public IQueryable<OrderItem> SelectAllOrderItems()
        {
            this.orderItemCollection =
                this.db.GetCollection<OrderItem>(GetCollectionName<OrderItem>());

            return this.orderItemCollection.AsQueryable();
        }

        public async ValueTask<OrderItem> SelectOrderItemByIdAsync(Guid orderItemId)
        {
            this.orderItemCollection =
                this.db.GetCollection<OrderItem>(GetCollectionName<OrderItem>());

            var orderItem = await this.orderItemCollection
                .Find(item => item.OrderItemID == orderItemId)
                .FirstOrDefaultAsync();

            return orderItem;
        }

        public async ValueTask<OrderItem> UpdateOrderItemAsync(OrderItem orderItem)
        {
            this.orderItemCollection =
                this.db.GetCollection<OrderItem>(GetCollectionName<OrderItem>());

            await this.orderItemCollection
                .ReplaceOneAsync(item => item.OrderItemID == orderItem.OrderItemID, orderItem);

            return orderItem;
        }

        public async ValueTask<OrderItem> DeleteOrderItemAsync(OrderItem orderItem)
        {
            this.orderItemCollection =
                this.db.GetCollection<OrderItem>(GetCollectionName<OrderItem>());

            await this.orderItemCollection
                .DeleteOneAsync(item => item.OrderItemID == orderItem.OrderItemID);

            return orderItem;
        }
    }
}

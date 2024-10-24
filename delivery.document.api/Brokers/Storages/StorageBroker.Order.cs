// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Orders;
using MongoDB.Driver;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        private IMongoCollection<Order> orderCollection;

        public async ValueTask<Order> InsertOrderAsync(Order order)
        {
            this.orderCollection =
                this.db.GetCollection<Order>(GetCollectionName<Order>());

            await this.orderCollection.InsertOneAsync(order);
            return order;
        }

        public IQueryable<Order> SelectAllOrders()
        {
            this.orderCollection =
                this.db.GetCollection<Order>(GetCollectionName<Order>());

            return this.orderCollection.AsQueryable();
        }

        public async ValueTask<Order> SelectOrderByIdAsync(Guid orderId)
        {
            this.orderCollection =
                this.db.GetCollection<Order>(GetCollectionName<Order>());

            var order = await this.orderCollection
                .Find(ord => ord.OrderID == orderId)
                .FirstOrDefaultAsync();

            return order;
        }

        public async ValueTask<Order> UpdateOrderAsync(Order order)
        {
            this.orderCollection =
                this.db.GetCollection<Order>(GetCollectionName<Order>());

            await this.orderCollection
                .ReplaceOneAsync(ord => ord.OrderID == order.OrderID, order);

            return order;
        }

        public async ValueTask<Order> DeleteOrderAsync(Order order)
        {
            this.orderCollection =
                this.db.GetCollection<Order>(GetCollectionName<Order>());

            await this.orderCollection
                .DeleteOneAsync(ord => ord.OrderID == order.OrderID);

            return order;
        }
    }
}

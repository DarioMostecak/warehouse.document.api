// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Customers;
using MongoDB.Driver;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        private IMongoCollection<Customer> customerCollection;

        public async ValueTask<Customer> InsertCustomerAsync(Customer customer)
        {
            this.customerCollection =
                this.db.GetCollection<Customer>(GetCollectionName<Customer>());

            await this.customerCollection.InsertOneAsync(customer);
            return customer;
        }

        public IQueryable<Customer> SelectAllCustomers()
        {
            this.customerCollection =
                this.db.GetCollection<Customer>(GetCollectionName<Customer>());

            return this.customerCollection.AsQueryable();
        }

        public async ValueTask<Customer> SelectCustomerByIdAsync(Guid customerId)
        {
            this.customerCollection =
                this.db.GetCollection<Customer>(GetCollectionName<Customer>());

            var customer = await this.customerCollection
                .Find(obj => obj.CustomerID == customerId)
                 .FirstOrDefaultAsync();

            return customer;
        }

        public async ValueTask<Customer> UpdateCustomerAsync(Customer customer)
        {
            this.customerCollection =
                this.db.GetCollection<Customer>(GetCollectionName<Customer>());

            await this.customerCollection
                .ReplaceOneAsync(obj => obj.CustomerID == customer.CustomerID, customer);

            return customer;
        }

        public async ValueTask<Customer> DeleteCustomerAsync(Customer customer)
        {
            this.customerCollection =
                this.db.GetCollection<Customer>(GetCollectionName<Customer>());

            await this.customerCollection
                .DeleteOneAsync(obj => obj.CustomerID == customer.CustomerID);

            return customer;
        }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Customers;

namespace delivery.document.api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Customer> InsertCustomerAsync(Customer customer);
        IQueryable<Customer> SelectAllCustomers();
        ValueTask<Customer> SelectCustomerByIdAsync(Guid customerId);
        ValueTask<Customer> UpdateCustomerAsync(Customer customer);
        ValueTask<Customer> DeleteCustomerAsync(Customer customer);
    }
}
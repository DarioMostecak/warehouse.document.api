// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Customers;

namespace delivery.document.api.Services.Foundations.Customers
{
    public interface ICustomerService
    {
        ValueTask<Customer> AddCustomerAsync(Customer customer);
        IQueryable<Customer> RetrieveAllCustomers();
        ValueTask<Customer> RetrieveCustomerByIdAsync(Guid customerId);
        ValueTask<Customer> ModifyCustomerAsync(Customer customer);
        ValueTask<Customer> RemoveCustomerByIdAsync(Guid customerId);
    }
}

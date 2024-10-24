using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Models.Customers;

namespace delivery.document.api.Services.Foundations.Customers
{
    public partial class CustomerService : ICustomerService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public CustomerService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Customer> AddCustomerAsync(Customer customer) =>
        TryCatch(async () =>
        {
            ValidateCustomerOnCreate(customer);

            return await this.storageBroker.InsertCustomerAsync(customer);
        });

        public IQueryable<Customer> RetrieveAllCustomers() =>
        TryCatch(() => this.storageBroker.SelectAllCustomers());

        public ValueTask<Customer> RetrieveCustomerByIdAsync(Guid customerId) =>
        TryCatch(async () =>
        {
            ValidateCustomerIdIsNull(customerId);
            Customer maybeCustomer = await this.storageBroker.SelectCustomerByIdAsync(customerId);
            ValidateStorageCustomer(maybeCustomer, customerId);

            return maybeCustomer;
        });

        public ValueTask<Customer> ModifyCustomerAsync(Customer customer) =>
        TryCatch(async () =>
        {
            ValidateCustomerOnModify(customer);
            Customer maybeCustomer = await this.storageBroker.SelectCustomerByIdAsync(customer.CustomerID);

            ValidateStorageCustomer(maybeCustomer, customer.CustomerID);
            ValidateAgainstStorageCustomerOnModify(inputCustomer: customer, storageCustomer: maybeCustomer);

            var updatedCustomer = await this.storageBroker.UpdateCustomerAsync(customer);

            return updatedCustomer;
        });

        public ValueTask<Customer> RemoveCustomerByIdAsync(Guid customerId) =>
        TryCatch(async () =>
        {
            ValidateCustomerIdIsNull(customerId);
            Customer maybeCustomer = await this.storageBroker.SelectCustomerByIdAsync(customerId);
            ValidateStorageCustomer(maybeCustomer, customerId);

            var deletedCustomer = await this.storageBroker.DeleteCustomerAsync(maybeCustomer);

            return deletedCustomer;
        });
    }

}

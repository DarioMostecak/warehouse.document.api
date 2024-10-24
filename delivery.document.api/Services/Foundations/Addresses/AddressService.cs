// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Models.Addresses;

namespace delivery.document.api.Services.Foundations.Addresses
{
    public partial class AddressService : IAddressService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public AddressService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Address> AddAddressAsync(Address address) =>
        TryCatch(async () =>
        {
            ValidateAddressOnCreate(address);

            return await this.storageBroker.InsertAddressAsync(address);
        });

        public IQueryable<Address> RetrieveAllAddresses() =>
        TryCatch(() => this.storageBroker.SelectAllAddresses());

        public ValueTask<Address> RetrieveAddressByIdAsync(Guid addressId) =>
        TryCatch(async () =>
        {
            ValidateAddressIdIsNull(addressId);
            Address maybeAddress = await this.storageBroker.SelectAddressByIdAsync(addressId);
            ValidateStorageAddress(maybeAddress, addressId);

            return maybeAddress;
        });

        public ValueTask<Address> ModifyAddressAsync(Address address) =>
        TryCatch(async () =>
        {
            ValidateAddressOnModify(address);
            Address maybeAddress = await this.storageBroker.SelectAddressByIdAsync(address.AddressID);

            ValidateStorageAddress(maybeAddress, address.AddressID);
            ValidateAgainstStorageAddressOnModify(inputAddress: address, storageAddress: maybeAddress);

            var updatedAddress = await this.storageBroker.UpdateAddressAsync(address);

            return updatedAddress;
        });

        public ValueTask<Address> RemoveAddressByIdAsync(Guid addressId) =>
        TryCatch(async () =>
        {
            ValidateAddressIdIsNull(addressId);
            Address maybeAddress = await this.storageBroker.SelectAddressByIdAsync(addressId);
            ValidateStorageAddress(maybeAddress, addressId);

            var deletedAddress = await this.storageBroker.DeleteAddressAsync(maybeAddress);

            return deletedAddress;
        });
    }
}


// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Addresses;

namespace delivery.document.api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Address> InsertAddressAsync(Address address);
        IQueryable<Address> SelectAllAddresses();
        ValueTask<Address> SelectAddressByIdAsync(Guid addressId);
        ValueTask<Address> UpdateAddressAsync(Address address);
        ValueTask<Address> DeleteAddressAsync(Address address);
    }
}

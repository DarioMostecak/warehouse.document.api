// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Addresses;
using MongoDB.Driver;
using System.Net.NetworkInformation;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        private IMongoCollection<Address> addressCollection;

        public async ValueTask<Address> InsertAddressAsync(Address address)
        {
            this.addressCollection =
                this.db.GetCollection<Address>(GetCollectionName<Address>());

            await this.addressCollection.InsertOneAsync(address);

            return address;
        }

        public IQueryable<Address> SelectAllAddresses()
        {
            this.addressCollection =
                this.db.GetCollection<Address>(GetCollectionName<Address>());

            return this.addressCollection.AsQueryable();
        }

        public async ValueTask<Address> SelectAddressByIdAsync(Guid addressId)
        {
            this.addressCollection =
                this.db.GetCollection<Address>(GetCollectionName<Address>());

            return await this.addressCollection
                .Find(address => address.AddressID == addressId)
                 .FirstOrDefaultAsync();
        }

        public async ValueTask<Address> UpdateAddressAsync(Address address)
        {
            this.addressCollection =
                this.db.GetCollection<Address>(GetCollectionName<Address>());

            await this.addressCollection
                .ReplaceOneAsync(obj => obj.AddressID == address.AddressID, address);

            return address;
        }

        public async ValueTask<Address> DeleteAddressAsync(Address address) 
        { 
            this.addressCollection =
                this.db.GetCollection<Address>(GetCollectionName<Address>());

            await this.addressCollection
                .DeleteOneAsync(obj => obj.AddressID == address.AddressID);

            return address;
        }
    }
}

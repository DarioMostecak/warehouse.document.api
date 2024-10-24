// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Shipments;
using MongoDB.Driver;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        private IMongoCollection<Shipment> shipmentCollection;

        public async ValueTask<Shipment> InsertShipmentAsync(Shipment shipment)
        {
            this.shipmentCollection =
                this.db.GetCollection<Shipment>(GetCollectionName<Shipment>());

            await this.shipmentCollection.InsertOneAsync(shipment);
            return shipment;
        }

        public IQueryable<Shipment> SelectAllShipments()
        {
            this.shipmentCollection =
                this.db.GetCollection<Shipment>(GetCollectionName<Shipment>());

            return this.shipmentCollection.AsQueryable();
        }

        public async ValueTask<Shipment> SelectShipmentByIdAsync(Guid shipmentId)
        {
            this.shipmentCollection =
                this.db.GetCollection<Shipment>(GetCollectionName<Shipment>());

            var shipment = await this.shipmentCollection
                .Find(ship => ship.ShipmentID == shipmentId)
                .FirstOrDefaultAsync();

            return shipment;
        }

        public async ValueTask<Shipment> UpdateShipmentAsync(Shipment shipment)
        {
            this.shipmentCollection =
                this.db.GetCollection<Shipment>(GetCollectionName<Shipment>());

            await this.shipmentCollection
                .ReplaceOneAsync(ship => ship.ShipmentID == shipment.ShipmentID, shipment);

            return shipment;
        }

        public async ValueTask<Shipment> DeleteShipmentAsync(Shipment shipment)
        {
            this.shipmentCollection =
                this.db.GetCollection<Shipment>(GetCollectionName<Shipment>());

            await this.shipmentCollection
                .DeleteOneAsync(ship => ship.ShipmentID == shipment.ShipmentID);

            return shipment;
        }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Models.Shipments;

namespace delivery.document.api.Services.Foundations.Shipments
{
    public partial class ShipmentService : IShipmentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public ShipmentService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<Shipment> AddShipmentAsync(Shipment shipment) =>
        TryCatch(async () =>
        {
            ValidateShipmentOnCreate(shipment);

            return await this.storageBroker.InsertShipmentAsync(shipment);
        });

        public IQueryable<Shipment> RetrieveAllShipments() =>
        TryCatch(() => this.storageBroker.SelectAllShipments());

        public ValueTask<Shipment> RetrieveShipmentByIdAsync(Guid shipmentId) =>
        TryCatch(async () =>
        {
            ValidateShipmentIdIsNull(shipmentId);
            Shipment maybeShipment = await this.storageBroker.SelectShipmentByIdAsync(shipmentId);
            ValidateStorageShipment(maybeShipment, shipmentId);

            return maybeShipment;
        });

        public ValueTask<Shipment> ModifyShipmentAsync(Shipment shipment) =>
        TryCatch(async () =>
        {
            ValidateShipmentOnModify(shipment);
            Shipment maybeShipment = await this.storageBroker.SelectShipmentByIdAsync(shipment.ShipmentID);

            ValidateStorageShipment(maybeShipment, shipment.ShipmentID);
            ValidateAgainstStorageShipmentOnModify(inputShipment: shipment, storageShipment: maybeShipment);

            var updatedShipment = await this.storageBroker.UpdateShipmentAsync(shipment);

            return updatedShipment;
        });

        public ValueTask<Shipment> RemoveShipmentByIdAsync(Guid shipmentId) =>
        TryCatch(async () =>
        {
            ValidateShipmentIdIsNull(shipmentId);
            Shipment maybeShipment = await this.storageBroker.SelectShipmentByIdAsync(shipmentId);
            ValidateStorageShipment(maybeShipment, shipmentId);

            var deletedShipment = await this.storageBroker.DeleteShipmentAsync(maybeShipment);

            return deletedShipment;
        });
    }

}

using delivery.document.api.Models.Shipments;

namespace delivery.document.api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Shipment> InsertShipmentAsync(Shipment shipment);
        IQueryable<Shipment> SelectAllShipments();
        ValueTask<Shipment> SelectShipmentByIdAsync(Guid shipmentId);
        ValueTask<Shipment> UpdateShipmentAsync(Shipment shipment);
        ValueTask<Shipment> DeleteShipmentAsync(Shipment shipment);
    }
}

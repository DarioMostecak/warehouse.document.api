// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Shipments;

namespace delivery.document.api.Services.Foundations.Shipments
{
    public interface IShipmentService
    {
        ValueTask<Shipment> AddShipmentAsync(Shipment shipment);
        IQueryable<Shipment> RetrieveAllShipments();
        ValueTask<Shipment> RetrieveShipmentByIdAsync(Guid shipmentId);
        ValueTask<Shipment> ModifyShipmentAsync(Shipment shipment);
        ValueTask<Shipment> RemoveShipmentByIdAsync(Guid shipmentId);
    }
}
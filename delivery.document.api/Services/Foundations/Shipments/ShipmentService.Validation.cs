// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Shipments.Exceptions;
using delivery.document.api.Models.Shipments;

namespace delivery.document.api.Services.Foundations.Shipments
{
    public partial class ShipmentService
    {
        private void ValidateShipmentOnCreate(Shipment shipment)
        {
            ValidateShipmentIsNull(shipment);

            Validate(
                (rule: IsInvalid(shipment.ShipmentID), parameter: nameof(Shipment.ShipmentID)),
                (rule: IsInvalid(shipment.OrderID), parameter: nameof(Shipment.OrderID)),
                (rule: IsInvalid(shipment.Carrier), parameter: nameof(Shipment.Carrier)),
                (rule: IsInvalid(shipment.TrackingNumber), parameter: nameof(Shipment.TrackingNumber)),
                (rule: IsInvalid(shipment.ShipmentDate), parameter: nameof(Shipment.ShipmentDate)),
                (rule: IsInvalid(shipment.EstimatedDeliveryDate), parameter: nameof(Shipment.EstimatedDeliveryDate)),
                (rule: IsInvalid(shipment.DeliveryStatus), parameter: nameof(Shipment.DeliveryStatus)),
                (rule: IsInvalid(shipment.CreatedAt), parameter: nameof(Shipment.CreatedAt)),
                (rule: IsInvalid(shipment.UpdatedAt), parameter: nameof(Shipment.UpdatedAt))
            );
        }

        private void ValidateShipmentOnModify(Shipment shipment)
        {
            ValidateShipmentIsNull(shipment);

            Validate(
                (rule: IsInvalid(shipment.ShipmentID), parameter: nameof(Shipment.ShipmentID)),
                (rule: IsInvalid(shipment.OrderID), parameter: nameof(Shipment.OrderID)),
                (rule: IsInvalid(shipment.Carrier), parameter: nameof(Shipment.Carrier)),
                (rule: IsInvalid(shipment.TrackingNumber), parameter: nameof(Shipment.TrackingNumber)),
                (rule: IsInvalid(shipment.ShipmentDate), parameter: nameof(Shipment.ShipmentDate)),
                (rule: IsInvalid(shipment.EstimatedDeliveryDate), parameter: nameof(Shipment.EstimatedDeliveryDate)),
                (rule: IsInvalid(shipment.DeliveryStatus), parameter: nameof(Shipment.DeliveryStatus)),
                (rule: IsInvalid(shipment.CreatedAt), parameter: nameof(Shipment.CreatedAt)),
                (rule: IsInvalid(shipment.UpdatedAt), parameter: nameof(Shipment.UpdatedAt)),
                (rule: IsSame(shipment.CreatedAt, shipment.UpdatedAt, nameof(Shipment.UpdatedAt)),
                parameter: nameof(Shipment.UpdatedAt))
            );
        }

        private static void ValidateAgainstStorageShipmentOnModify(
            Shipment inputShipment, Shipment storageShipment)
        {
            Validate(
                (rule: IsNotSame(inputShipment.ShipmentID, storageShipment.ShipmentID, nameof(Shipment.ShipmentID)),
                parameter: nameof(Shipment.ShipmentID)),

                (rule: IsNotSame(inputShipment.CreatedAt, storageShipment.CreatedAt, nameof(Shipment.CreatedAt)),
                parameter: nameof(Shipment.CreatedAt)),

                (rule: IsSame(inputShipment.UpdatedAt, storageShipment.UpdatedAt, nameof(Shipment.UpdatedAt)),
                parameter: nameof(Shipment.UpdatedAt))
            );
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "ID is required."
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text) || text.Length > 100,
            Message = "Text must not exceed 100 characters and cannot be null or whitespace."
        };

        private static dynamic IsInvalid(DateTime date) => new
        {
            Condition = date == default,
            Message = "Date is required."
        };

        private static dynamic IsNotSame(Guid firstId, Guid secondId, string secondIdName) => new
        {
            Condition = firstId != secondId,
            Message = $"ID does not match with {secondIdName}."
        };

        private static dynamic IsNotSame(DateTime firstDate, DateTime secondDate, string secondDateName) => new
        {
            Condition = Math.Abs((firstDate - secondDate).TotalSeconds) >= 1,
            Message = $"Date does not match with {secondDateName}."
        };

        private static dynamic IsSame(DateTime firstDate, DateTime secondDate, string secondDateName) => new
        {
            Condition = Math.Abs((firstDate - secondDate).TotalSeconds) <= 1,
            Message = $"Date matches with {secondDateName}."
        };

        private static void ValidateShipmentIsNull(Shipment shipment)
        {
            if (shipment == null)
            {
                throw new NullShipmentException();
            }
        }

        private static void ValidateShipmentIdIsNull(Guid shipmentID)
        {
            if (IsInvalid(shipmentID))
            {
                var invalidShipmentException = new InvalidShipmentException(nameof(Shipment.ShipmentID), shipmentID);
                throw invalidShipmentException;
            }
        }

        private static void ValidateStorageShipment(Shipment storageShipment,
            Guid shipmentID)
        {
            if (storageShipment is null) throw new NotFoundShipmentException(shipmentID);
        }

        private static void Validate(params (dynamic rule, string parameter)[] validations)
        {
            var invalidShipmentException = new InvalidShipmentException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidShipmentException.UpsertDataList(key: parameter, value: rule.Message);
                }
            }

            invalidShipmentException.ThrowIfContainsErrors();
        }
    }

}

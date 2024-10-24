// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Addresses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public static void RegisterAddressMap()
        {
            BsonClassMap.RegisterClassMap<Address>(addressMap =>
            {
                addressMap.MapIdField(address => address.AddressID)
                          .SetSerializer(new GuidSerializer(BsonType.String))
                          .SetElementName("_address_id")
                          .SetIsRequired(true);

                addressMap.MapField(address => address.AddressType)
                          .SetElementName("address_type")
                          .SetIsRequired(true);

                addressMap.MapField(address => address.AddressLine1)
                          .SetElementName("address_line1")
                          .SetIsRequired(true);

                addressMap.MapField(address => address.AddressLine2)
                          .SetElementName("address_line2");

                addressMap.MapField(address => address.City)
                          .SetElementName("city")
                          .SetIsRequired(true);

                addressMap.MapField(address => address.State)
                          .SetElementName("state")
                          .SetIsRequired(true);

                addressMap.MapField(address => address.PostalCode)
                          .SetElementName("postal_code")
                          .SetIsRequired(true);

                addressMap.MapField(address => address.Country)
                          .SetElementName("country")
                          .SetIsRequired(true);

                addressMap.MapField(address => address.CreatedAt)
                          .SetSerializer(new DateTimeSerializer(BsonType.DateTime))
                          .SetElementName("created_at")
                          .SetIsRequired(true);

                addressMap.MapField(address => address.UpdatedAt)
                          .SetSerializer(new DateTimeSerializer(BsonType.DateTime))
                          .SetElementName("updated_at")
                          .SetIsRequired(true);
            });
        }
    }
}

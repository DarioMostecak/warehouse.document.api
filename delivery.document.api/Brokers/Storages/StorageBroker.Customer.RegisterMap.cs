// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Models.Customers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public static void RegisterCustomerMap()
        {
            BsonClassMap.RegisterClassMap<Customer>(customerMap =>
            {
                customerMap.MapIdField(customer => customer.CustomerID)
                           .SetSerializer(new GuidSerializer(BsonType.String))
                           .SetElementName("_customer_id")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.FirstName)
                           .SetElementName("first_name")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.LastName)
                           .SetElementName("last_name")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.Email)
                           .SetElementName("email")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.PhoneNumber)
                           .SetElementName("phone_number")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.AddressLine)
                           .SetElementName("address_line")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.City)
                           .SetElementName("city")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.State)
                           .SetElementName("state")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.PostalCode)
                           .SetElementName("postal_code")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.Country)
                           .SetElementName("country")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.CreatedAt)
                           .SetSerializer(new DateTimeSerializer(BsonType.DateTime))
                           .SetElementName("created_at")
                           .SetIsRequired(true);

                customerMap.MapField(customer => customer.UpdatedAt)
                           .SetSerializer(new DateTimeSerializer(BsonType.DateTime))
                           .SetElementName("updated_at")
                           .SetIsRequired(true);


                customerMap.MapField(customer => customer.Orders)
                          .SetElementName("orders");

            });
        }
    }
}

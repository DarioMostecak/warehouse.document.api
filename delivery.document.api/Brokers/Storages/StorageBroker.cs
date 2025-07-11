﻿// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Attributes;
using MongoDB.Driver;

namespace delivery.document.api.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        private readonly IConfiguration configuration;
        private readonly IMongoDatabase db;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            RegisterClassMap();
            this.db = GetDatabase();
        }

        private string GetCollectionName<T>() where T : class
        {
            return (typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                .FirstOrDefault() as BsonCollectionAttribute)!.CollectionName;
        }

        private IMongoDatabase GetDatabase()
        {
            var connectionString = this.configuration["MongoDbOptions:ConnectionString"];
            var client = new MongoClient(connectionString);

            return client
                .GetDatabase(this.configuration["MongoDbOptions:DatabaseName"]);
        }

        public static void RegisterClassMap()
        {
            RegisterCustomerMap();
        }
    }

}

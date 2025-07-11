// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2023 Dario Mostecak. All rights reserved.
// ---------------------------------------------------------------


using delivery.document.api.Brokers.DateTimes;
using delivery.document.api.Brokers.Loggings;
using delivery.document.api.Brokers.Storages;
using delivery.document.api.Models.Addresses;
using delivery.document.api.Models.ExceptionModels;
using delivery.document.api.Services.Foundations.Addresses;
using MongoDB.Driver;
using Moq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using Tynamix.ObjectFiller;

namespace delivery.document.api.test.unit.Services.Foundations.Addresses
{
    public partial class AddressServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly IAddressService addressService;

        public AddressServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();

            this.addressService = new AddressService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object,
                dateTimeBroker: this.dateTimeBrokerMock.Object);
        }

        private static Address CreateRandomAddress() =>
            CreateRandomAddressFiller(dates: DateTime.UtcNow).Create();

        private static MongoException GetMongoException() =>
            (MongoException)FormatterServices.GetSafeUninitializedObject(typeof(MongoException));

        private static MongoWriteException GetMongoWriteException() =>
            (MongoWriteException)FormatterServices.GetSafeUninitializedObject(typeof(MongoWriteException));

        private static MongoWriteException GetMongoDuplicateKeyException() =>
           (MongoWriteException)FormatterServices.GetUninitializedObject(typeof(MongoWriteException));

        private static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException =>
                actualException.Message == expectedException.Message
                && (actualException.InnerException as ExceptionModel).DataEquals(expectedException.InnerException.Data);
        }

        private static Filler<Address> CreateRandomAddressFiller(DateTime dates)
        {
            var filler = new Filler<Address>();
            Guid addressId = Guid.NewGuid();

            filler.Setup()
                .OnProperty(address => address.AddressID).Use(addressId)
                .OnProperty(address => address.AddressType).Use(new MnemonicString(1, 5, 15))
                .OnProperty(address => address.AddressLine1).Use(new MnemonicString(1, 10, 30))
                .OnProperty(address => address.AddressLine2).Use(new MnemonicString(1, 10, 30))
                .OnProperty(address => address.City).Use(new MnemonicString(1, 5, 15))
                .OnProperty(address => address.State).Use(new MnemonicString(1, 5, 15))
                .OnProperty(address => address.PostalCode).Use(new MnemonicString(1, 5, 10))
                .OnProperty(address => address.Country).Use(new MnemonicString(1, 5, 15))
                .OnProperty(address => address.CreatedAt).Use(dates)
                .OnProperty(address => address.UpdatedAt).Use(dates.AddDays(10));

            return filler;
        }

        private static IEnumerable<object[]> InvalidAddressData() =>
            new List<object[]>
            {
                new object[] { Guid.Empty, null, null, null, null, null, null, null, DateTime.MinValue }
            };

    }
}


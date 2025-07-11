// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak. All rights reserved.
// ---------------------------------------------------------------

using delivery.document.api.Models.Addresses;
using delivery.document.api.Models.Addresses.Exceptions;
using MongoDB.Driver;
using Moq;

namespace delivery.document.api.test.unit.Services.Foundations.Addresses
{
    public partial class AddressServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddWhenAddressAlreadyExistsAndLogItAsync()
        {
            // given
            Address someAddress = CreateRandomAddress();
            MongoWriteException mongoDuplicateKeyException =
                GetMongoDuplicateKeyException();

            var alreadyExistsAddressException =
                new AlreadyExistsAddressException(mongoDuplicateKeyException);

            var expectedAddressValidationException =
                new AddressValidationException(
                    alreadyExistsAddressException,
                    alreadyExistsAddressException.Data);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertAddressAsync(It.IsAny<Address>()))
                  .ThrowsAsync(mongoDuplicateKeyException);

            // when
            ValueTask<Address> addAddressTask =
                this.addressService.AddAddressAsync(someAddress);

            // then
            await Assert.ThrowsAsync<AddressValidationException>(() =>
               addAddressTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                   expectedAddressValidationException))),
                      Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.InsertAddressAsync(It.IsAny<Address>()),
                  Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAddIfMongoExceptionErrorOccursAndLogItAsync()
        {
            // given
            Address someAddress = CreateRandomAddress();
            MongoException mongoException = GetMongoException();

            var failedAddressServiceException =
                new FailedAddressServiceException(mongoException);

            var expectedAddressDependencyException =
                new AddressDependencyException(failedAddressServiceException);

            this.storageBrokerMock.Setup(broker =>
               broker.InsertAddressAsync(It.IsAny<Address>()))
                .ThrowsAsync(mongoException);

            // when
            ValueTask<Address> addAddressTask =
                this.addressService.AddAddressAsync(someAddress);

            // then
            await Assert.ThrowsAsync<AddressDependencyException>(() =>
                addAddressTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                   expectedAddressDependencyException))),
                      Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.InsertAddressAsync(It.IsAny<Address>()),
                  Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAddIfExceptionOccursAndLogItAsync()
        {
            // given
            Address someAddress = CreateRandomAddress();
            var serviceException = new Exception();

            var failedAddressServiceException =
                new FailedAddressServiceException(serviceException);

            var expectedAddressServiceException =
                new AddressServiceException(failedAddressServiceException);

            this.storageBrokerMock.Setup(broker =>
               broker.InsertAddressAsync(It.IsAny<Address>()))
                .ThrowsAsync(serviceException);

            // when
            ValueTask<Address> addAddressTask =
                this.addressService.AddAddressAsync(someAddress);

            // then
            await Assert.ThrowsAsync<AddressServiceException>(() =>
                addAddressTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                   expectedAddressServiceException))),
                      Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.InsertAddressAsync(It.IsAny<Address>()),
                  Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}

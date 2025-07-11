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
        public async Task ShouldThrowDependencyExceptionOnRemoveByIdIfMongoExceptionErrorOccursAndLogItAsync()
        {
            // given
            Guid someId = Guid.NewGuid();
            MongoException mongoException = GetMongoException();

            var failedAddressServiceException =
                new FailedAddressServiceException(mongoException);

            var expectedAddressDependencyException =
                new AddressDependencyException(failedAddressServiceException);

            this.storageBrokerMock.Setup(broker =>
               broker.SelectAddressByIdAsync(It.IsAny<Guid>()))
                .ThrowsAsync(mongoException);

            // when
            ValueTask<Address> removeAddressTask =
                this.addressService.RemoveAddressByIdAsync(someId);

            // then
            await Assert.ThrowsAsync<AddressDependencyException>(() =>
                removeAddressTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                   expectedAddressDependencyException))),
                      Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.SelectAddressByIdAsync(It.IsAny<Guid>()),
                  Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.DeleteAddressAsync(It.IsAny<Address>()),
                  Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRemoveByIdIfExceptionOccursAndLogItAsync()
        {
            // given
            Guid someId = Guid.NewGuid();
            var serviceException = new Exception();

            var failedAddressServiceException =
                new FailedAddressServiceException(serviceException);

            var expectedAddressServiceException =
                new AddressServiceException(failedAddressServiceException);

            this.storageBrokerMock.Setup(broker =>
               broker.SelectAddressByIdAsync(It.IsAny<Guid>()))
                .ThrowsAsync(serviceException);

            // when
            ValueTask<Address> removeAddressTask =
                this.addressService.RemoveAddressByIdAsync(someId);

            // then
            await Assert.ThrowsAsync<AddressServiceException>(() =>
                removeAddressTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                   expectedAddressServiceException))),
                      Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.SelectAddressByIdAsync(It.IsAny<Guid>()),
                  Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.DeleteAddressAsync(It.IsAny<Address>()),
                  Times.Never);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}

// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2025 Dario Mostecak. All rights reserved.
// ---------------------------------------------------------------

using delivery.document.api.Models.Addresses.Exceptions;
using MongoDB.Driver;
using Moq;

namespace delivery.document.api.test.unit.Services.Foundations.Addresses
{
    public partial class AddressServiceTests
    {
        [Fact]
        public void ShouldThrowDependencyExceptionOnRetrieveAllIfMongoExceptionErrorOccursAndLogItAsync()
        {
            // given
            MongoException mongoException = GetMongoException();

            var failedAddressServiceException =
                    new FailedAddressServiceException(mongoException);

            var expectedAddressDependencyException =
                new AddressDependencyException(failedAddressServiceException);

            this.storageBrokerMock.Setup(broker =>
               broker.SelectAllAddresses())
                .Throws(mongoException);

            // when 
            Assert.Throws<AddressDependencyException>(() =>
                this.addressService.RetrieveAllAddresses());

            //then
            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                   expectedAddressDependencyException))),
                      Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.SelectAllAddresses(),
                  Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldThrowServiceExceptionOnRetrieveAllIfExceptionOccursAndLogItAsync()
        {
            // given
            Exception serviceException = new Exception();

            var failedAddressServiceException =
                new FailedAddressServiceException(serviceException);

            var expectedAddressServiceException =
                new AddressServiceException(failedAddressServiceException);

            this.storageBrokerMock.Setup(broker =>
               broker.SelectAllAddresses())
                .Throws(serviceException);

            // when . then
            Assert.Throws<AddressServiceException>(() =>
                this.addressService.RetrieveAllAddresses());

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs(
                   expectedAddressServiceException))),
                      Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.SelectAllAddresses(),
                  Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}

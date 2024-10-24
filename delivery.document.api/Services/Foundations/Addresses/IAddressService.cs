using delivery.document.api.Models.Addresses;

namespace delivery.document.api.Services.Foundations.Addresses
{
    public interface IAddressService
    {
        ValueTask<Address> AddAddressAsync(Address address);
        IQueryable<Address> RetrieveAllAddresses();
        ValueTask<Address> RetrieveAddressByIdAsync(Guid addressId);
        ValueTask<Address> ModifyAddressAsync(Address address);
        ValueTask<Address> RemoveAddressByIdAsync(Guid addressId);
    }
}

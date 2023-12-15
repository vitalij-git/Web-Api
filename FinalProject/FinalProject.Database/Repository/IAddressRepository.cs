using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.Address;

namespace FinalProject.Database.Repository
{
    public interface IAddressRepository
    {
        public Task AddAddress(Address address);

        public Task<Address> GetAddress(Guid personalId);

        public Task UpdateAddressCity(UpdateAddressCityDto updateAddressCityDto);

        public Task UpdateAddressStreet(UpdateAddressStreetDto updateAddressStreetDto);

        public Task UpdateAddressBuildingNumber(UpdateAddressBuildingNumberDto updateAddressBuildingNumberDto);

        public Task UpdateAddressApartmentNumber(UpdateAddressApartmentNumberDto updateAddressApartmentNumberDto);

        public Task<IList<Address>> GetAddresses();
    }
}
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.Address;

namespace FinalProject.BusinessLogic.Services
{
    public interface IAddressService
    {
        public Task AddAddress(AddAddressDto addAddressDto);

        public Task<GetAddressDto> GetAddress(Guid personalInformationId);

        public Task UpdateAddressStreet(UpdateAddressStreetDto updateAddressStreetDto);

        public Task UpdateAddressCity(UpdateAddressCityDto updateAddressCityDto);

        public Task UpdateAddressBuildingNumber(UpdateAddressBuildingNumberDto updateAddressBuildingNumberDto);

        public Task UpdateAddressApartmentNumber(UpdateAddressApartmentNumberDto updateAddressApartmentNumberDto);

        public Task<IList<GetAddressDto>> GetAddresses();
    }
}
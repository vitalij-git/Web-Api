using Azure.Core;
using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.Address;
using FinalProject.Database.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DbContextService _dbContextService;

        public AddressRepository(DbContextService dbContextService)
        {
            _dbContextService = dbContextService;
        }

        public async Task AddAddress(Address address)
        {
            _dbContextService.Addresses.Add(address);
            var request = await _dbContextService.PersonalInformations.SingleOrDefaultAsync( p => p.Id == address.PersonalInformationId);
            if (request == null) 
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The requested personal information id is not found");
            }
            request.AddressId = address.Id;
            request.Address = address;
            await _dbContextService.SaveChangesAsync(); 
        }

        public async Task<Address> GetAddress(Guid personalId)
        {
          var result = await _dbContextService.Addresses.SingleOrDefaultAsync(ad => ad.PersonalInformationId == personalId);
            if (result == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The requested address is not found");
            }
            return result;
        }

        public async Task<IList<Address>> GetAddresses()
        {
            return await _dbContextService.Addresses.ToListAsync();
        }

        public async Task UpdateAddressApartmentNumber(UpdateAddressApartmentNumberDto updateAddressApartmentNumberDto)
        {
            var result = await GetAddress(updateAddressApartmentNumberDto.PersonalInformationId);
            result.ApartmentNumber = updateAddressApartmentNumberDto.ApartmentNumber;
            result.UpdatedAt = DateTime.Now;
            await _dbContextService.SaveChangesAsync();
        }

        public async Task UpdateAddressBuildingNumber(UpdateAddressBuildingNumberDto updateAddressBuildingNumberDto)
        {
            var result = await GetAddress(updateAddressBuildingNumberDto.PersonalInformationId);
            result.BuildingNumber = updateAddressBuildingNumberDto.BuildingNumber;
            result.UpdatedAt = DateTime.Now;
            await _dbContextService.SaveChangesAsync();
        }


        public async Task UpdateAddressCity(UpdateAddressCityDto updateAddressCityDto)
        {
            var result = await GetAddress(updateAddressCityDto.PersonalInformationId);
            result.City = updateAddressCityDto.City;
            result.UpdatedAt = DateTime.Now;
            await _dbContextService.SaveChangesAsync();
        }

        public async Task UpdateAddressStreet(UpdateAddressStreetDto updateAddressStreetDto)
        {
            var result = await GetAddress(updateAddressStreetDto.PersonalInformationId);
            result.Street = updateAddressStreetDto.Street;
            result.UpdatedAt = DateTime.Now;
            await _dbContextService.SaveChangesAsync();
        }
    }
}

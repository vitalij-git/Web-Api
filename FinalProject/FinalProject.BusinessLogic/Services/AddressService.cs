using FinalProject.BusinessLogic.ErrorResponseModel;
using FinalProject.BusinessLogic.Models;
using FinalProject.BusinessLogic.Models.Dto.Address;
using FinalProject.Database.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        
        public async Task AddAddress(AddAddressDto addAddressDto)
        {
            if (addAddressDto == null || string.IsNullOrWhiteSpace(addAddressDto.City) || string.IsNullOrWhiteSpace(addAddressDto.Street) || addAddressDto.PersonalInformationId == Guid.Empty)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            if (addAddressDto.City.Any(char.IsDigit) || ContainsSymbol(addAddressDto.City))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The city name should not contain a numerical digit or any symbol. Please enter a valid city name");
            }
            if (addAddressDto.Street.Any(char.IsDigit) || ContainsSymbol(addAddressDto.Street))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The city name should not contain a numerical digit or any symbol. Please enter a valid city name");
            }
            var address = new Address()
            {
                City = addAddressDto.City,  
                Street = addAddressDto.Street,
                BuildingNumber = addAddressDto.BuildingNumber,
                ApartmentNumber = addAddressDto.ApartmentNumber,
                CreatedAt = DateTime.Now,
                PersonalInformationId = addAddressDto.PersonalInformationId

            };
            await _addressRepository.AddAddress(address);
           
        }

        public async Task<GetAddressDto> GetAddress(Guid personalInformationId)
        {
            if(personalInformationId == Guid.Empty)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
            var result = await _addressRepository.GetAddress(personalInformationId);
            if (result == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The request is not Found");
            }
            var addressDto = new GetAddressDto()
            {
                City = result.City,
                Street = result.Street,
                BuildingNumber = result.BuildingNumber,
                ApartmentNumber = result.ApartmentNumber
            };
            return addressDto;
        }

        public async Task<IList<GetAddressDto>> GetAddresses()
        {
            var addresses = await _addressRepository.GetAddresses();
            if(addresses == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "The request is not Found");
            }
            var addressesDto = new List<GetAddressDto>();
            foreach( var address in addresses)
            {
                addressesDto.Add(new GetAddressDto()
                {
                    City = address.City,
                    Street = address.Street,
                    BuildingNumber = address.BuildingNumber,
                    ApartmentNumber = address.ApartmentNumber
                });
            } 
            return addressesDto;
        }

        public async Task UpdateAddressApartmentNumber(UpdateAddressApartmentNumberDto updateAddressApartmentNumberDto)
        {

            CheckInput(updateAddressApartmentNumberDto.PersonalInformationId);
            await _addressRepository.UpdateAddressApartmentNumber(updateAddressApartmentNumberDto);
        }

        public async Task UpdateAddressBuildingNumber(UpdateAddressBuildingNumberDto updateAddressBuildingNumberDto)
        {

            CheckInput(updateAddressBuildingNumberDto.PersonalInformationId);
            await _addressRepository.UpdateAddressBuildingNumber(updateAddressBuildingNumberDto);    
        }

        public async Task UpdateAddressCity(UpdateAddressCityDto updateAddressCityDto)
        {

            CheckInputs(updateAddressCityDto.PersonalInformationId, updateAddressCityDto.City);
            if (updateAddressCityDto.City.Any(char.IsDigit) || ContainsSymbol(updateAddressCityDto.City))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The city name should not contain a numerical digit or any symbol. Please enter a valid city name");
            }
            await _addressRepository.UpdateAddressCity(updateAddressCityDto);               
        }

        public async Task UpdateAddressStreet(UpdateAddressStreetDto updateAddressStreetDto)
        {

            CheckInputs(updateAddressStreetDto.PersonalInformationId, updateAddressStreetDto.Street);
            if (updateAddressStreetDto.Street.Any(char.IsDigit) || ContainsSymbol(updateAddressStreetDto.Street))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The city name should not contain a numerical digit or any symbol. Please enter a valid city name");
            }
            await _addressRepository.UpdateAddressStreet(updateAddressStreetDto);       
        }

        private void CheckInputs (Guid personalInformationId, string value)
        {
            if (personalInformationId == Guid.Empty || string.IsNullOrEmpty(value))
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
        }

        private void CheckInput(Guid personalInformationId)
        {
            if (personalInformationId == Guid.Empty)
            {
                throw new HttpStatusException(HttpStatusCode.BadRequest, "The request contains an empty or null value");
            }
        }

        private bool ContainsSymbol(string input)
        {
            string pattern = @"[^A-Za-z0-9\s]"; 
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}

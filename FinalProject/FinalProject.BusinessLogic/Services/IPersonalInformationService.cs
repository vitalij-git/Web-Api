using FinalProject.Database.Models.Dto.PersonalInformation;

namespace FinalProject.BusinessLogic.Services
{
    public interface IPersonalInformationService
    {
        public Task AddPersonalInformation(AddPersonalInformationDto personalInformationDto);

        public Task<GetPersonalInformationDto> GetPersonalInformation(Guid userId);

        public Task<IList<GetPersonalInformationDto>> GetAllPersonalInformation();

        public Task UpdatePersonalInformationFirstName(UpdatePersonalInformationFirstNameDto updatePersonalInformationFirstNameDto);

        public Task UpdatePersonalInformationLastName(UpdatePersonalInformationLastNameDto updatePersonalInformationLastNameDto);

        public Task UpdatePersonalInformationPersonalCode(UpdatePersonalInformationPersonalCodeDto updatePersonalInformationPersonalCodeDto);

        public Task UpdatePersonalInformationTelNumber(UpdatePersonalInformationTelNumberDto updatePersonalInformationTelNumberDto);

        public Task UpdatePersonalInformationEmail(UpdatePersonalInformationEmailDto updatePersonalInformationEmailDto);
    }
}
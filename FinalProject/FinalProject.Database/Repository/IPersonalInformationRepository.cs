using FinalProject.BusinessLogic.Models;
using FinalProject.Database.Models.Dto.PersonalInformation;

namespace FinalProject.Database.Repository
{
    public interface IPersonalInformationRepository
    {
        public Task AddPersonalInformation(PersonalInformation personalInformation);

        public Task<PersonalInformation> GetPersonalInformationById(Guid userId);

        public Task<IList<PersonalInformation>> GetAllPersonalInformation();

        public Task UpdatePersonalFirstName(UpdatePersonalInformationFirstNameDto updatePersonalInformationFirstNameDto);

        public Task UpdatePersonalLastName(UpdatePersonalInformationLastNameDto updatePersonalInformationLastNameDto);

        public Task UpdatePersonalCode(UpdatePersonalInformationPersonalCodeDto updatePersonalInformationPersonalCodeDto);

        public Task UpdatePersonalTelNumber(UpdatePersonalInformationTelNumberDto updatePersonalInformationTelNumberDto);

        public Task UpdatePersonalEmail(UpdatePersonalInformationEmailDto updatePersonalInformationEmailDto);

    }
}
using BackEnd.Models;
using BackEnd.Models.Dto.SubElement;

namespace BackEnd.Services
{
    public interface ISubElementService
    {
        public Task CreateSubElement(SubElementDto SubElementDto);
        public Task<IList<SubElement>> GetSubElements();
        public Task<SubElement> GetSubElement(int subElementId);
        public Task DeleteSubElement(int subElementId);
    }
}
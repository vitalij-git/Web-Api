using BackEnd.Models;

namespace BackEnd.Repository
{
    public interface ISubElementRepository
    {
        public Task CreateSubElement(SubElement subElement);
        public Task<IList<SubElement>> GetSubElements();
        public Task<SubElement> GetSubElement(int subElementId);
        public Task DeleteSubElement(int subElementId);
    }
}
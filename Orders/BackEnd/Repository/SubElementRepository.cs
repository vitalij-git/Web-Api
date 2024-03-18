using BackEnd.Database;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class SubElementRepository : ISubElementRepository
    {
        private readonly DatabaseConnection _connection;

        public SubElementRepository(DatabaseConnection connection)
        {
            _connection = connection;
        }
        public async Task CreateSubElement(SubElement subElement)
        {
            _connection.SubElements.Add(subElement);
            await _connection.SaveChangesAsync();   
        }

        public async Task DeleteSubElement(int subElementId)
        {
            var request = await _connection.SubElements.FirstOrDefaultAsync(_ => _.Id == subElementId);
            if (request != null)
            {
                _connection.SubElements.Remove(request);
                await _connection.SaveChangesAsync();
            }
        }

        public async Task<SubElement> GetSubElement(int subElementId)
        {
            var request = await _connection.SubElements.FirstOrDefaultAsync(_ => _.Id == subElementId);
            if (request != null)
            {
                return request;
            }
            return null;
        }

        public async Task<IList<SubElement>> GetSubElements()
        {
           return await _connection.SubElements.ToListAsync();
        }
    }
}

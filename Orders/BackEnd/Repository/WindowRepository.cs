using BackEnd.Database;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repository
{
    public class WindowRepository : IWindowRepository
    {
        private readonly DatabaseConnection _connection;

        public WindowRepository(DatabaseConnection connection)
        {
            _connection = connection;
        }

        public async Task DeleteWindow(int windowId)
        {
            var request = await _connection.Windows.FirstOrDefaultAsync(_ => _.Id == windowId);
            if (request != null)
            {
                _connection.Windows.Remove(request);
                await _connection.SaveChangesAsync();
            }
        }

        public async Task<Window> GetWindow(int windowId)
        {
            var request = await _connection.Windows.Include(sub => sub.SubElements).FirstOrDefaultAsync(_ => _.Id == windowId);
            if (request != null)
            {
                return request;
            }
            return null;
        }

        public async Task<IList<Window>> GetWindows()
        {
            var windows = await _connection.Windows.Include(sub => sub.SubElements).ToListAsync();  
            return windows;
        }

        public async Task CreateWindow(Window window)
        {
            _connection.Windows.Add(window);    
            await _connection.SaveChangesAsync();
        }
    }
}

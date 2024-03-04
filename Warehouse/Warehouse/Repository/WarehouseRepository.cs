using Microsoft.EntityFrameworkCore;
using WarehouseStore.Database;
using WarehouseStore.Models;

namespace WarehouseStore.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly DbContextService _dbContextService;

        public WarehouseRepository(DbContextService dbContextService)
        {
            _dbContextService = dbContextService;
        }

 
        public async Task<IList<Warehouse>> GetWarehouses()
        {
            return await _dbContextService.Warehouses.ToListAsync();    
        }

        public async Task<Warehouse> GetWarehouse(int warehouseId)
        {
           var result = await _dbContextService.Warehouses.SingleOrDefaultAsync(wr => wr.Id == warehouseId);
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}

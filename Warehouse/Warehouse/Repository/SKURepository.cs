using Microsoft.EntityFrameworkCore;
using WarehouseStore.Database;
using WarehouseStore.Models;

namespace WarehouseStore.Repository
{
    public class SKURepository : ISKURepository
    {
        private readonly DbContextService _dbContextService;

        public SKURepository(DbContextService dbContextService)
        {
            _dbContextService = dbContextService;
        }
  
        public async Task<IList<SKU>> GetListOfSKU()
        {
            return await _dbContextService.SKUs.ToListAsync();
        }


        public async Task<SKU> GetSKUById(int skuId)
        {
            var sku = await _dbContextService.SKUs.SingleOrDefaultAsync(sk => sk.Id == skuId);
            if (sku == null)
            {
                return null;
            }
            var warehouseSKUInfo = await _dbContextService.warehouseSKUInfos.SingleOrDefaultAsync(sk => sk.Id == sku.Id);
            sku.WarehousesSKUInfos.Add(warehouseSKUInfo);
            return sku;
        }
    }
}

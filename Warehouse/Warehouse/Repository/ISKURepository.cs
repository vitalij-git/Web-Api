using WarehouseStore.Models;

namespace WarehouseStore.Repository
{
    public interface ISKURepository
    {
        public Task<IList<SKU>> GetListOfSKU();
        public Task<SKU> GetSKUById(int skuId);
    }
}
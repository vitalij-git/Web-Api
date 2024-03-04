using WarehouseStore.Models;

namespace WarehouseStore.Repository
{
    public interface IWarehouseRepository
    {
        public Task<IList<Warehouse>> GetWarehouses();
        public Task<Warehouse> GetWarehouse(int warehouseId);
    }
}
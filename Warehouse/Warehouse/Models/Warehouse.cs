using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseStore.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int GoodsStored { get; set; }
        public int GoodsReserved { get; set; }
        public int FreeSpace { get; set; }

        
    }
}

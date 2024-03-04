using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseStore.Models
{
    public class WarehouseSKUInfo
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int PlannedDeliveryQuantity { get; set; }


        [ForeignKey("SKUId")]
        public SKU SKU { get; set; }
        public int SKUId { get; set; }
    }
}

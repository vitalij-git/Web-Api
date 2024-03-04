using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseStore.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("SKUId")]
        public SKU SKU { get; set; }
        public int SKUId { get; set; }

        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }
        public int WarehouseId { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
        public int InvoiceId { get; set; }
    }
}

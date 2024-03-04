using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseStore.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationTime { get; set; }

        [ForeignKey("SKUId")]
        public SKU SKU { get; set; }
        public int SKUId { get; set;}


    }
}

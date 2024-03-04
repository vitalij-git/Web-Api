using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseStore.Models.Dto
{
    public class ReservationDto
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationTime { get; set; }
        public int SKUId { get; set; }
    }
}

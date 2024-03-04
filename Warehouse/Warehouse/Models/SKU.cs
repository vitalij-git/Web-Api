namespace WarehouseStore.Models
{
    public class SKU
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public IList<Reservation> Reservations { get; set; }
        public IList<WarehouseSKUInfo> WarehousesSKUInfos { get; set; }


    }
}

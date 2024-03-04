namespace WarehouseStore.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }

        public IList<InvoiceItem> InvoiceItems { get; set; }
    }
}

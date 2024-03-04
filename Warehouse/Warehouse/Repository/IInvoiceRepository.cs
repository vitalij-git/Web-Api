using WarehouseStore.Models;

namespace WarehouseStore.Repository
{
    public interface IInvoiceRepository
    {
        public Task<IList<Invoice>> GetInvoices();
        public Task<Invoice> GetInvoice(int invoiceId);
    }
}
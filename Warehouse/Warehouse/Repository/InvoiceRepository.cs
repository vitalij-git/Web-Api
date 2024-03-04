using Microsoft.EntityFrameworkCore;
using WarehouseStore.Database;
using WarehouseStore.Models;

namespace WarehouseStore.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DbContextService _dbContextService;

        public InvoiceRepository(DbContextService dbContextService)
        {
            _dbContextService = dbContextService;
        }


        public async Task<IList<Invoice>> GetInvoices()
        {
            return await _dbContextService.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoice(int invoiceId)
        {
            var result = await _dbContextService.Invoices.SingleOrDefaultAsync(inv => inv.Id == invoiceId);
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}

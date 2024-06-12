using Facturosaurus.Domain.Entities;

namespace Facturosaurus.Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllInvoices();
        Task Create(Invoice invoice);
        Task<Invoice> GetInvoiceById(int id);
    }
}

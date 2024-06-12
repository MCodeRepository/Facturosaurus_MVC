using Facturosaurus.Api.Entities;
using Facturosaurus.Domain.Entities;
using Facturosaurus.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Facturosaurus.Infrastructure.Repositories
{
    public class InvoicesRepository : IInvoiceRepository
    {
        private readonly FacturosaurusDbContext _dbContext;

        public InvoicesRepository(FacturosaurusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Invoice invoice)
        {
            invoice.Month = invoice.ExecutionDate.Month;
            invoice.Year = invoice.ExecutionDate.Year;
            invoice.CreateDate = DateTime.Now;
            invoice.Number = GetLastNumberOfInvoice(invoice);
            invoice.PaidDate = invoice.Paid ? invoice.PaidDate : DateTime.MinValue;

            _dbContext.Invoices.Add(invoice);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoices()
        {
            var invoices = await _dbContext
            .Invoices
            .Include(i => i.CompanyDetails)
            .Include(c => c.Customer)
            .Include(k => k.Correction)
            .ThenInclude(co => co.Items)
            .Include(c => c.DocumentType)
            .Include(c => c.PaymentType)
            .Include(i => i.Items)
            .ThenInclude(it => it.TaxType)
            .Include(i => i.Items)
            .ThenInclude(it => it.UnitType)
            .ToListAsync();

            return invoices;
        }

        public async Task<Invoice> GetInvoiceById(int id)
        {
            var invoice = await _dbContext
            .Invoices
            .Include(i => i.CompanyDetails)
            .Include(c => c.Customer)
            .Include(k => k.Correction)
            .ThenInclude(co => co.Items)
            .Include(c => c.DocumentType)
            .Include(c => c.PaymentType)
            .Include(i => i.Items)
            .ThenInclude(it => it.TaxType)
            .Include(i => i.Items)
            .ThenInclude(it => it.UnitType)
            .FirstOrDefaultAsync(i => i.Id==id);

            return invoice;
        }

        private int GetLastNumberOfInvoice(Invoice newInvoice)
        {

            var invoices = _dbContext.Invoices.Where(i => i.DocumentTypeId == newInvoice.DocumentTypeId).ToList();

            var number = (from invoice in invoices
                          where invoice.Year == newInvoice.Year && invoice.Month == newInvoice.Month
                          orderby invoice.Number descending
                          select invoice.Number).FirstOrDefault() + 1;

            return number;
        }
    }
}

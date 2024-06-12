using Facturosaurus.Api.Entities;
using Facturosaurus.Domain.Entities;
using Facturosaurus.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Facturosaurus.Infrastructure.Repositories
{
    public class PaymentTypesRepository : IPaymentTypesRepository
    {
        private readonly FacturosaurusDbContext _dbContext;

        public PaymentTypesRepository(FacturosaurusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PaymentType>> GetActivePaymentTypes()
        {
            var paymantsTypes = await _dbContext.PaymentTypes.Where(x => x.Active == true).ToListAsync();

            return paymantsTypes;
        }
    }
}

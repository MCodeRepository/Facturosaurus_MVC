using Facturosaurus.Api.Entities;
using Facturosaurus.Domain.Entities;
using Facturosaurus.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Facturosaurus.Infrastructure.Repositories
{
    public class TaxTypesRepository : ITaxTypesRepository
    {
        private readonly FacturosaurusDbContext _dbContext;

        public TaxTypesRepository(FacturosaurusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaxType>> GetActiveTaxTypes()
        {
            var taxTypes = await _dbContext.TaxTypes.Where(x => x.Active == true).ToArrayAsync();

            return taxTypes;
        }
    }
}

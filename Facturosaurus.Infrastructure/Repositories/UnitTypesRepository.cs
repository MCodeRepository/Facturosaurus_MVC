using Facturosaurus.Api.Entities;
using Facturosaurus.Domain.Entities;
using Facturosaurus.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Facturosaurus.Infrastructure.Repositories
{
    public class UnitTypesRepository : IUnitTypesRepository
    {
        private readonly FacturosaurusDbContext _dbContext;

        public UnitTypesRepository(FacturosaurusDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UnitType>> GetActiveUnitTypes()
        {
            var unitTypes = await _dbContext.UnitTypes.Where(x => x.Active == true).ToListAsync();

            return unitTypes;
        }
    }
}

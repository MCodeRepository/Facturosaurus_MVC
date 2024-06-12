using Facturosaurus.Domain.Entities;

namespace Facturosaurus.Domain.Interfaces
{
    public interface IUnitTypesRepository
    {
        Task<IEnumerable<UnitType>> GetActiveUnitTypes();
    }
}

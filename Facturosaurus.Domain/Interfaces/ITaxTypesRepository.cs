using Facturosaurus.Domain.Entities;

namespace Facturosaurus.Domain.Interfaces
{
    public interface ITaxTypesRepository
    {
        Task<IEnumerable<TaxType>> GetActiveTaxTypes();
    }
}

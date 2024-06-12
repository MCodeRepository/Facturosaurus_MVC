using Facturosaurus.Domain.Entities;

namespace Facturosaurus.Domain.Interfaces
{
    public interface IPaymentTypesRepository
    {
        Task<IEnumerable<PaymentType>> GetActivePaymentTypes();
    }
}

using MediatR;

namespace Facturosaurus.Application.TaxTypes.Queries.GetAllActiveTaxTypes
{
    public class GetActiveTaxTypesQuery : TaxTypeDto, IRequest<IEnumerable<TaxTypeDto>>
    {
    }
}

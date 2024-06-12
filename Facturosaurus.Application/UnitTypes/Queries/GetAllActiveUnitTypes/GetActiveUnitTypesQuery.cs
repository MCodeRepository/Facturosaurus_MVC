using MediatR;

namespace Facturosaurus.Application.UnitTypes.Queries.GetAllActiveTaxTypes
{
    public class GetActiveUnitTypesQuery: UnitTypeDto, IRequest<IEnumerable<UnitTypeDto>>
    {
    }
}

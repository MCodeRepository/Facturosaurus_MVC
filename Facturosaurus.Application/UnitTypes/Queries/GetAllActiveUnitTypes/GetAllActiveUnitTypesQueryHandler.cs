using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.UnitTypes.Queries.GetAllActiveTaxTypes
{
    public class GetAllActiveUnitTypesQueryHandler : IRequestHandler<GetActiveUnitTypesQuery, IEnumerable<UnitTypeDto>>
    {
        private readonly IUnitTypesRepository _unitTypesRepository;
        private readonly IMapper _mapper;

        public GetAllActiveUnitTypesQueryHandler(IUnitTypesRepository unitTypesRepository, IMapper mapper)
        {
            _unitTypesRepository = unitTypesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnitTypeDto>> Handle(GetActiveUnitTypesQuery request, CancellationToken cancellationToken)
        {
            var unitTypes = await _unitTypesRepository.GetActiveUnitTypes();
            var unitTypesDto = _mapper.Map<IEnumerable<UnitTypeDto>>(unitTypes);

            return unitTypesDto;
        }
    }
}

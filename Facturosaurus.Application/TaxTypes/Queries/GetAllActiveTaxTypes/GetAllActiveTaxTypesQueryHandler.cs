using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.TaxTypes.Queries.GetAllActiveTaxTypes
{
    public class GetAllActiveTaxTypesQueryHandler : IRequestHandler<GetActiveTaxTypesQuery, IEnumerable<TaxTypeDto>>
    {

        private readonly ITaxTypesRepository _taxTypesRepository;
        private readonly IMapper _mapper;

        public GetAllActiveTaxTypesQueryHandler(ITaxTypesRepository taxTypesRepository, IMapper mapper)
        {
            _taxTypesRepository = taxTypesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaxTypeDto>> Handle(GetActiveTaxTypesQuery request, CancellationToken cancellationToken)
        {
            var taxTypes = await _taxTypesRepository.GetActiveTaxTypes();
            var taxTypesDto = _mapper.Map<IEnumerable<TaxTypeDto>>(taxTypes);

            return taxTypesDto;
        }
    }
}

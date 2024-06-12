using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.CompanyDetails.Quires.GetLastCompanyDetails
{
    internal class GetLastCompanyDetailsQueryHandler : IRequestHandler<GetLastCompanyDetailsQuery, CompanyDetailsDto>
    {
        private readonly ICompanyDetailsRepository _companyDetailsRepository;
        private readonly IMapper _mapper;

        public GetLastCompanyDetailsQueryHandler(ICompanyDetailsRepository companyDetailsRepository, IMapper mapper)
        {
            _companyDetailsRepository = companyDetailsRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDetailsDto> Handle(GetLastCompanyDetailsQuery request, CancellationToken cancellationToken)
        {
            var companyDetails = await _companyDetailsRepository.GetLast();
            var companyDetailsDto = _mapper.Map<CompanyDetailsDto>(companyDetails);

            return companyDetailsDto;
        }
    }
}

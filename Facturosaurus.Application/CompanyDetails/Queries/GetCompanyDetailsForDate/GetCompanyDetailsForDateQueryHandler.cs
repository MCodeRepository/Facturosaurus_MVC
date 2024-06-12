using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.CompanyDetails.Quires.GetCompanyDetailsForDate
{
    public class GetCompanyDetailsForDateQueryHandler : IRequestHandler<GetCompanyDetailsForDateQuery, CompanyDetailsDto>
    {
        private readonly ICompanyDetailsRepository _companyDetailsRepository;
        private readonly IMapper _mapper;

        public GetCompanyDetailsForDateQueryHandler(ICompanyDetailsRepository companyDetailsRepository, IMapper mapper)
        {
            _companyDetailsRepository = companyDetailsRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDetailsDto> Handle(GetCompanyDetailsForDateQuery request, CancellationToken cancellationToken)
        {
            var companyDetails = await _companyDetailsRepository.GetCompanyDetailsForTheDate(request.Date);
            var companyDetailsDto = _mapper.Map<CompanyDetailsDto>(companyDetails);

            return companyDetailsDto;
        }
    }
}

using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.CompanyDetails.Quires.GetAllCompanyDetails
{
    public class GetAllCompanyDetailsQueryHandler : IRequestHandler<GetAllCompanyDetailsQuery, IEnumerable<CompanyDetailsDto>>
    {
        private readonly ICompanyDetailsRepository _companyDetailsRepository;
        private readonly IMapper _mapper;

        public GetAllCompanyDetailsQueryHandler(ICompanyDetailsRepository companyDetailsRepository, IMapper mapper)
        {
            _companyDetailsRepository = companyDetailsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyDetailsDto>> Handle(GetAllCompanyDetailsQuery request, CancellationToken cancellationToken)
        {
            var companyDetails = await _companyDetailsRepository.GetAll();
            var companyDetailsDto = _mapper.Map<IEnumerable<CompanyDetailsDto>>(companyDetails);

            return companyDetailsDto;
        }
    }
}

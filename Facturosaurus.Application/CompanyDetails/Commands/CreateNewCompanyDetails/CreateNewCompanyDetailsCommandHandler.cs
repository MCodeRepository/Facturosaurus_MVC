using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails
{
    public class CreateNewCompanyDetailsCommandHandler : IRequestHandler<CreateNewCompanyDetailsCommand>
    {
        private readonly ICompanyDetailsRepository _companyDetailsRepository;
        private readonly IMapper _mapper;

        public CreateNewCompanyDetailsCommandHandler(ICompanyDetailsRepository companyDetailsRepository, IMapper mapper)
        {
            _companyDetailsRepository = companyDetailsRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateNewCompanyDetailsCommand request, CancellationToken cancellationToken)
        {
            var companyDetails = _mapper.Map<Domain.Entities.CompanyDetails>(request);

            if(companyDetails == null) {
                return Unit.Value;
            }

            await _companyDetailsRepository.Create(companyDetails);

            return Unit.Value;
            
        }
    }
}

using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueriesHandler : IRequestHandler<GetCustomerByIdQueries, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueriesHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQueries request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
            var customerDto = _mapper.Map<CustomerDto>(customer);

            return customerDto;
        }
    }
}

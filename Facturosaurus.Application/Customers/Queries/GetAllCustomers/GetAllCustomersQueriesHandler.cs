using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;


namespace Facturosaurus.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueriesHandler : IRequestHandler<GetAllCustomersQueries, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetAllCustomersQueriesHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        async Task<IEnumerable<CustomerDto>> IRequestHandler<GetAllCustomersQueries, IEnumerable<CustomerDto>>.Handle(GetAllCustomersQueries request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllCustomers();
            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return customersDto;
        }
    }
}

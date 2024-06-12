using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.Customers.Commands.DeleteCustomerById
{
    public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public DeleteCustomerByIdCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.DeleteCustomer(request.CustomerId);

            return Unit.Value;
        }
    }
}

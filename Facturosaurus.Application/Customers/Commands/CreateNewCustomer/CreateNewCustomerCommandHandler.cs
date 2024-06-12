using AutoMapper;
using Facturosaurus.Domain.Entities;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.Customers.Commands.CreateNewCustomer
{
    public class CreateNewCustomerCommandHandler : IRequestHandler<CreateNewCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateNewCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Domain.Entities.Customer>(request);


            if (request.StreetName != null && request.StreetName != "")
            {
                customer.Adresses.Add(new CustomerAddress
                {
                    CustomerId = request.Id,
                    OrderNumber = 1,
                    StreetName = request.StreetName,
                    BildingNumber = request.BildingNumber,
                    ApartmentNumber = request.ApartmentNumber,
                    ZipCode = request.ZipCode,
                    City = request.City,
                    Default = true,
                });
            }

            if (request.AccountNumber != null && request.AccountNumber != "")
            {
                customer.BankAccounts.Add(new CustomerBankAccount
                {
                    CustomerId = request.Id,
                    OrderNumber = 1,
                    BankName = request.BankName,
                    AccountNumber = request.AccountNumber!,
                    AccountCurrency = request.AccountCurrency,
                    Default = true
                });
            }

            if (request.AddressEmail != null && request.AddressEmail != "")
            {
                customer.EmailAdresses.Add(new CustomerEmailAddress
                {
                    CustomerId = request.Id,
                    OrderNumber = 1,
                    AddressEmail = request.AddressEmail!,
                    Default = true,
                });
            }

            if (request.PhoneNumber != null && request.PhoneNumber != "") 
            {
                customer.Phones.Add(new CustomerPhone
                {
                    CustomerId = request.Id,
                    OrderNumber = 1,
                    PhoneNumber = request.PhoneNumber!,
                    Default = true,
                });
            }


            if (customer == null)
            {
                return Unit.Value;
            }

            await _customerRepository.Create(customer);

            return Unit.Value;
        }
    }
}

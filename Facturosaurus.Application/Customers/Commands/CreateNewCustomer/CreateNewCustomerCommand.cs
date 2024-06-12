using MediatR;

namespace Facturosaurus.Application.Customers.Commands.CreateNewCustomer
{
    public class CreateNewCustomerCommand : CustomerDto, IRequest
    {
    }
}

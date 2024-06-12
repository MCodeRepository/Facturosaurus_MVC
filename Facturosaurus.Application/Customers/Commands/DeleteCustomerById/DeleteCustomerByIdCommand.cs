using MediatR;

namespace Facturosaurus.Application.Customers.Commands.DeleteCustomerById
{
    public class DeleteCustomerByIdCommand : IRequest
    {
        public int CustomerId { get; set; }
    }
}

using MediatR;

namespace Facturosaurus.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueries : IRequest<IEnumerable<CustomerDto>>
    {
    }
}

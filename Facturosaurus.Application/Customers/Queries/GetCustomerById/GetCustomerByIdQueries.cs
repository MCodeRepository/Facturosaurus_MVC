using MediatR;

namespace Facturosaurus.Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueries : IRequest<CustomerDto>
    {
        public int CustomerId { get; set; } = default;
    }
}

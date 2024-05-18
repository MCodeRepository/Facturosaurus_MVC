using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueries : IRequest<CustomerDto>
    {
        public int CustomerId { get; set; } = default;
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueries : IRequest<IEnumerable<CustomerDto>>
    {
    }
}

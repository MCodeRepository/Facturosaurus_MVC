using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.Customers.Commands.DeleteCustomerById
{
    public class DeleteCustomerByIdCommand : IRequest
    {
        public int CustomerId { get; set; }
    }
}

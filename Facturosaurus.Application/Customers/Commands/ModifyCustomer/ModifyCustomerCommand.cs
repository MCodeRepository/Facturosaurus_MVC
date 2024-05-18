using AutoMapper;
using Facturosaurus.Application.CompanyDetails;
using Facturosaurus.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.Customers.Commands.ModifyCustomer
{
    public class ModifyCustomerCommand : CustomerDto, IRequest
    {
    }
}

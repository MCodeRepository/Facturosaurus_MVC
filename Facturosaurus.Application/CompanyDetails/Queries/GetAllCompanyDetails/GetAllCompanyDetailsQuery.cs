using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.CompanyDetails.Quires.GetAllCompanyDetails
{
    public class GetAllCompanyDetailsQuery : IRequest<IEnumerable<CompanyDetailsDto>>
    {
    }
}

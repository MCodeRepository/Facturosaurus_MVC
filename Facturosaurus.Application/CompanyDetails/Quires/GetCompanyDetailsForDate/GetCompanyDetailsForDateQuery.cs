using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.CompanyDetails.Quires.GetCompanyDetailsForDate
{
    public class GetCompanyDetailsForDateQuery : IRequest<CompanyDetailsDto>
    {
        public DateTime Date { get; set; } = default!;
    }
}

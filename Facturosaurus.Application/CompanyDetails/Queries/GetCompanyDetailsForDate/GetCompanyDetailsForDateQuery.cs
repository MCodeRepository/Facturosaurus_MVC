using MediatR;

namespace Facturosaurus.Application.CompanyDetails.Quires.GetCompanyDetailsForDate
{
    public class GetCompanyDetailsForDateQuery : IRequest<CompanyDetailsDto>
    {
        public DateTime Date { get; set; } = default!;
    }
}

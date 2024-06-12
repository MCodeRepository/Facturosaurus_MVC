using MediatR;

namespace Facturosaurus.Application.CompanyDetails.Quires.GetAllCompanyDetails
{
    public class GetAllCompanyDetailsQuery : IRequest<IEnumerable<CompanyDetailsDto>>
    {
    }
}

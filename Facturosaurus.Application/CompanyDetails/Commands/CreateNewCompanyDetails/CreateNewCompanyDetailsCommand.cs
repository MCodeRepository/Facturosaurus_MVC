using MediatR;

namespace Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails
{
    public class CreateNewCompanyDetailsCommand : CompanyDetailsDto, IRequest
    {
    }
}

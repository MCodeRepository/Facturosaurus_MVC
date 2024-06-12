using MediatR;

namespace Facturosaurus.Application.PaymentTypes.Queries.GetActivePaymentTypes
{
    public class GetActivePaymentTypesQuery:PaymentTypeDto,IRequest<IEnumerable<PaymentTypeDto>>
    {
    }
}

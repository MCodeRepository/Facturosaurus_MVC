using MediatR;

namespace Facturosaurus.Application.Invoices.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQuery : InvoiceDto, IRequest<InvoiceDto>
    {
        public int InvoiceId { get; set; }
    }
}

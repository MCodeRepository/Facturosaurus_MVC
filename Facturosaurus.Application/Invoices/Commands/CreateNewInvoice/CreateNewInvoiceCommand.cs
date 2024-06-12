using MediatR;

namespace Facturosaurus.Application.Invoices.Commands.CreateNewInvoice
{
    public class CreateNewInvoiceCommand: InvoiceDto, IRequest
    {
    }
}

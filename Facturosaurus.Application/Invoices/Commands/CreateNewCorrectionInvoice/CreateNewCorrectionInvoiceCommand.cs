using MediatR;

namespace Facturosaurus.Application.Invoices.Commands.CreateNewCorrectionInvoice
{
    public class CreateNewCorrectionInvoiceCommand : InvoiceDto, IRequest
    {
    }
}

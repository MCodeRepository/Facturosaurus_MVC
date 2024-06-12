using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.Invoices.Queries.GetAllInvoices
{
    public class GetAllInvoicesQuery : InvoiceDto,IRequest<IEnumerable<InvoiceDto>>
    {
    }
}

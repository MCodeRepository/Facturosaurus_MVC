using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Application.Invoices.Queries.GetAllInvoices
{
    public class GetAllInvoicesQueryHandler //: IRequestHandler<GetAllInvoicesQuery, IEnumerable<InvoiceDto>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetAllInvoicesQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<InvoiceDto>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

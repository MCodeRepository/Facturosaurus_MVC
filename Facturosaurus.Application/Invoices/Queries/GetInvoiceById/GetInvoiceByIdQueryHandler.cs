using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.Invoices.Queries.GetInvoiceById
{
    internal class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceDto>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<InvoiceDto> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceRepository.GetInvoiceById(request.InvoiceId);

            var invoiceDto = _mapper.Map<InvoiceDto>(invoice);

            return invoiceDto;
        }
    }
}

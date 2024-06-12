using AutoMapper;
using Facturosaurus.Domain.Entities;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.Invoices.Commands.CreateNewInvoice
{
    public class CreateNewInvoiceCommandHandler : IRequestHandler<CreateNewInvoiceCommand>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public CreateNewInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateNewInvoiceCommand request, CancellationToken cancellationToken)
        {
            // var invoice = _mapper.Map<Invoice>(request);

            //var invoiceItems = new List<InvoiceItems>();
            var invoiceItems = _mapper.Map<List<InvoiceItems>>(request.Items);

            var invoice = new Invoice()
            {
                Id = request.Id,
                Number = request.Number,
                Month = request.Month,
                Year = request.Year,
                CreateDate = request.CreateDate,
                ExecutionDate = request.ExecutionDate,
                PaymentDate = request.PaymentDate,
                CustomerName = request.CustomerName,
                CustomerNipNumber = request.CustomerNipNumber,
                CustomerStreetName = request.CustomerStreetName,
                CustomerBildingNumber = request.CustomerBildingNumber,
                CustomerApartmentNumber = request.CustomerApartmentNumber,
                CustomerZipCode = request.CustomerZipCode,
                CustomerCity = request.CustomerCity,
                NetAmount = request.NetAmount,
                GrossAmount = request.GrossAmount,
                VatAmount = request.VatAmount,
                Paid = request.Paid,
                PaidDate = request.PaidDate,
                CorrectionReason = request.CorrectionReason,
                Author = request.Author,
                CompanyDetailsId = request.CompanyDetailsId,
                CustomerId = request.CustomerId,
                CorrectionId = request.CorrectionId,
                DocumentTypeId = request.DocumentTypeId,
                PaymentTypeId = request.PaymentTypeId,
                Items = invoiceItems
            };

            if (invoice == null)
            {
                return Unit.Value;
            }

            await _invoiceRepository.Create(invoice);

            return Unit.Value;
        }
    }
}

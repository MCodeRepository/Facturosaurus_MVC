using AutoMapper;
using Facturosaurus.Domain.Interfaces;
using MediatR;

namespace Facturosaurus.Application.PaymentTypes.Queries.GetActivePaymentTypes
{
    public class GetActivePaymentTypesQueryHandler : IRequestHandler<GetActivePaymentTypesQuery, IEnumerable<PaymentTypeDto>>
    {
        private readonly IPaymentTypesRepository _paymentTypesRepository;
        private readonly IMapper _mapper;

        public GetActivePaymentTypesQueryHandler(IPaymentTypesRepository paymentTypesRepository, IMapper mapper)
        {
            _paymentTypesRepository = paymentTypesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentTypeDto>> Handle(GetActivePaymentTypesQuery request, CancellationToken cancellationToken)
        {
            var paymentTypes = await _paymentTypesRepository.GetActivePaymentTypes();
            var paymentTypesDto = _mapper.Map<IEnumerable<PaymentTypeDto>>(paymentTypes);

            return paymentTypesDto;
        }
    }
}

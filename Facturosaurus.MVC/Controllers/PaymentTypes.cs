using AutoMapper;
using Facturosaurus.Application.PaymentTypes.Queries.GetActivePaymentTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Facturosaurus.MVC.Controllers
{
    public class PaymentTypes:Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PaymentTypes(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("PaymentTypes")]
        public async Task<IActionResult> GetActivePaymentTypes()
        {
            var paymentTypes = await _mediator.Send(new GetActivePaymentTypesQuery());

            if(paymentTypes.IsNullOrEmpty())
                return NotFound();

            return Ok(paymentTypes);
        }
    }
}
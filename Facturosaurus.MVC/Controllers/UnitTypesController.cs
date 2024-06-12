using AutoMapper;
using Facturosaurus.Application.PaymentTypes.Queries.GetActivePaymentTypes;
using Facturosaurus.Application.UnitTypes.Queries.GetAllActiveTaxTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Facturosaurus.MVC.Controllers
{
    public class UnitTypesController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UnitTypesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveUnitTypes()
        {
            var unitTypes = await _mediator.Send(new GetActiveUnitTypesQuery());

            if (unitTypes.IsNullOrEmpty())
                return NotFound();

            return Ok(unitTypes);
        }
    }
}

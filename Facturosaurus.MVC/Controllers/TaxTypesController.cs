using AutoMapper;
using Facturosaurus.Application.TaxTypes.Queries.GetAllActiveTaxTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Facturosaurus.MVC.Controllers
{
    public class TaxTypesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TaxTypesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveTaxTypes()
        {
            var taxTypes = await _mediator.Send(new GetActiveTaxTypesQuery());

            if (taxTypes.IsNullOrEmpty())
                return NotFound();

            return Ok(taxTypes);
        }
    }
}

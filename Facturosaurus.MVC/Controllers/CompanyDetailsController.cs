using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Facturosaurus.Application.CompanyDetails.Quires.GetAllCompanyDetails;
using Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails;
using Facturosaurus.Application.CompanyDetails.Quires.GetCompanyDetailsForDate;

namespace Facturosaurus.MVC.Controllers
{
    public class CompanyDetailsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CompanyDetailsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var companyDetails = await _mediator.Send(new GetAllCompanyDetailsQuery());
            
            return View(companyDetails);
        }

        [HttpGet]
        [Route("/CompanyDetails/{date:datetime}")]
        public async Task<IActionResult> GetCmpanyNameByDate(DateTime date)
        {
            var companyDetails = await _mediator.Send(new GetCompanyDetailsForDateQuery() { Date = date});

            return Ok(companyDetails);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateNewCompanyDetails(CreateNewCompanyDetailsCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(command);

            return RedirectToAction("Index");
        }
    }
}

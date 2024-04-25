using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Facturosaurus.Application.CompanyDetails.Quires.GetAllCompanyDetails;
using Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails;
using Facturosaurus.Domain.Entities;
using Facturosaurus.Application.CompanyDetails.Quires.GetLastCompanyDetails;
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
            //var LastCompanyDetails = await _mediator.Send(new GetLastCompanyDetailsQuery());
            //var comm = new GetCompanyDetailsForDateQuery();
            //comm.Date = new DateTime(2022, 11, 11);
            //var CompanyDetailsForDate = await _mediator.Send(comm);

            
            return View(companyDetails);
        }

        
        [HttpPost]
        [Route("CompanyDetails/CreateNewCompanyDetails")]
        public async Task<IActionResult> CreateNewCompanyDetails(CreateNewCompanyDetailsCommand command)
        {
            var test = new CreateNewCompanyDetailsCommand();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Ok();
        }
    }
}

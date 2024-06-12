using AutoMapper;
using Facturosaurus.Application.Invoices.Commands.CreateNewCorrectionInvoice;
using Facturosaurus.Application.Invoices.Commands.CreateNewInvoice;
using Facturosaurus.Application.Invoices.Queries.GetAllInvoices;
using Facturosaurus.Application.Invoices.Queries.GetInvoiceById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Facturosaurus.MVC.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public InvoicesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/Invoices")]
        public async Task<IActionResult> Invoices()
        {
            var invoices = await _mediator.Send(new GetAllInvoicesQuery());

            return View(invoices);
        }

        [HttpPost]
        [Route("/Invoices")]
        public async Task<IActionResult> Create([FromBody]CreateNewInvoiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("/Invoices/Correction")]
        public async Task<IActionResult> CreateCorrection([FromBody] CreateNewCorrectionInvoiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("Invoices/{id}")]
        public async Task<IActionResult> Invoice(int id)
        {
            var invoice = await _mediator.Send(new GetInvoiceByIdQuery() { InvoiceId = id });

            return Ok(invoice);
        }

        public async Task<IActionResult> CreateNewInvoice()
        {
            var inv = new CreateNewInvoiceCommand();
            return View(inv);
        }

        [HttpGet]
        [Route("/Invoices/Print/{id}")]
        public async Task<IActionResult> PrintInvoice(int id)
        {
            var invoice = await _mediator.Send(new GetInvoiceByIdQuery() { InvoiceId=id} );

            if(invoice.DocumentTypeId == 2)
                return View("PrintInvoiceCorrection", invoice);
            return View(invoice);
        }

    }
}

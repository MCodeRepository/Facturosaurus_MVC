using AutoMapper;
using Facturosaurus.Application.CompanyDetails.Commands.CreateNewCompanyDetails;
using Facturosaurus.Application.CompanyDetails.Quires.GetAllCompanyDetails;
using Facturosaurus.Application.Customers.Commands.CreateNewCustomer;
using Facturosaurus.Application.Customers.Commands.DeleteCustomerById;
using Facturosaurus.Application.Customers.Commands.ModifyCustomer;
using Facturosaurus.Application.Customers.Queries.GetAllCustomers;
using Facturosaurus.Application.Customers.Queries.GetCustomerById;
using Facturosaurus.Domain.Entities;
using Facturosaurus.MVC.Extensions;
using Facturosaurus.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Facturosaurus.MVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Customers()
        {
            var customers = await _mediator.Send(new GetAllCustomersQueries());   

            return View(customers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCustomer(CreateNewCustomerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("Customer/{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQueries() { CustomerId = id});

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyCustomer(ModifyCustomerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        [Route("Customer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _mediator.Send(new DeleteCustomerByIdCommand() { CustomerId = id });

            return Ok(customer);
        }
    }
}

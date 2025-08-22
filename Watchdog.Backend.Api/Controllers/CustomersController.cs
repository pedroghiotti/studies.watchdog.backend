using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watchdog.Backend.Application.Features.Customers.Commands.RegisterCustomer;
using Watchdog.Backend.Application.Features.Customers.Queries.GetCustomerDetail;
using Watchdog.Backend.Application.Features.Customers.Queries.GetCustomersList;
using Watchdog.Backend.Domain.Entities;

namespace Watchdog.Backend.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController (IMediator mediator, IMapper mapper)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await mediator.Send(new GetCustomersListQuery());
        return Ok(customers);
    }

    [HttpGet("{customerId:guid}")]
    public async Task<IActionResult> GetCustomerById(Guid customerId)
    {
        var customer = await mediator.Send(new GetCustomerDetailQuery{CustomerId = customerId});
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<RegisterCustomerCommandResponse>> RegisterCustomer([FromBody] CustomerRegisterDto customerRegisterDto)
    {
        var registerCustomerCommand = mapper.Map<RegisterCustomerCommand>(customerRegisterDto);
        var response = await mediator.Send(registerCustomerCommand);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        var newCustomerId = response.Customer!.CustomerId;
        return CreatedAtAction(nameof(GetCustomerById), new { customerId = newCustomerId }, response);
    }
}
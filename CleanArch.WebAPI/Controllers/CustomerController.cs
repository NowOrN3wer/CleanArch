using CleanArch.Application.Features.Customers.Add;
using CleanArch.Application.Features.Customers.Delete;
using CleanArch.Application.Features.Customers.GetAll;
using CleanArch.Application.Features.Customers.Update;
using CleanArch.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebAPI.Controllers;

[Authorize]
public sealed class CustomerController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllCustomersCommand(), CancellationToken.None);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand request)
    {
        var response = await _mediator.Send(request, CancellationToken.None);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCustomerCommand request)
    {
        var response = await _mediator.Send(request, CancellationToken.None);
        return StatusCode(response.StatusCode, response);
    }    
    
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteCustomerCommand request)
    {
        var response = await _mediator.Send(request, CancellationToken.None);
        return StatusCode(response.StatusCode, response);
    }
}
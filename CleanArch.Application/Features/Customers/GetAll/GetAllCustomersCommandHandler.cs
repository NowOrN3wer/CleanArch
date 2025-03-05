using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace CleanArch.Application.Features.Customers.GetAll;

internal sealed class GetAllCustomersCommandHandler(ICustomerRepository customerRepository)
    : IRequestHandler<GetAllCustomersCommand, Result<List<Customer>>>
{
    public async Task<Result<List<Customer>>> Handle(GetAllCustomersCommand request,
        CancellationToken cancellationToken)
    {
        var result = await customerRepository.GetAll().ToListAsync(cancellationToken: cancellationToken);
        return result;
    }
}
using AutoMapper;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace CleanArch.Application.Features.Customers.Add;

public class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateCustomerCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var isTaxNumberExist =
            await customerRepository.AnyAsync(p => p.TaxNumber == request.taxnumber, cancellationToken);
        if (isTaxNumberExist)
        {
            return Result<bool>.Failure("Tax number already exist");
        }

        var customer = mapper.Map<Customer>(request);
        await customerRepository.AddAsync(customer, cancellationToken);

        return await unitOfWork.SaveChangesAsync(cancellationToken) > 0;
    }
}
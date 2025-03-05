using AutoMapper;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace CleanArch.Application.Features.Customers.Update;

public class UpdateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateCustomerCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer =
            await customerRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.id, cancellationToken);

        if (customer is null)
        {
            return Result<bool>.Failure("Customer not exists");
        }

        if (customer.TaxNumber != request.taxnumber)
        {
            var isTaxNumberExist =
                await customerRepository.AnyAsync(p => p.TaxNumber == request.taxnumber, cancellationToken);
            if (isTaxNumberExist)
            {
                return Result<bool>.Failure("Tax number already exist");
            }
        }

        mapper.Map(request, customer);

        return await unitOfWork.SaveChangesAsync(cancellationToken) > 0;
    }
}
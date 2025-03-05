using AutoMapper;
using CleanArch.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace CleanArch.Application.Features.Customers.Delete;

public class DeleteCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<DeleteCustomerCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer =
            await customerRepository.GetByExpressionAsync(p => p.Id == request.id, cancellationToken);

        if (customer is null)
        {
            return Result<bool>.Failure("Customer not exists");
        }

        mapper.Map(request, customer);
        customerRepository.Delete(customer);
        return await unitOfWork.SaveChangesAsync(cancellationToken) > 0;
    }
}
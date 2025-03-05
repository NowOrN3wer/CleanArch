using MediatR;
using TS.Result;

namespace CleanArch.Application.Features.Customers.Delete;

public sealed record DeleteCustomerCommand(Guid id) : IRequest<Result<bool>>;
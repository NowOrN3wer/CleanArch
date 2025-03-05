using MediatR;
using TS.Result;

namespace CleanArch.Application.Features.Customers.Update;

public sealed record UpdateCustomerCommand(
    Guid id,
    string name,
    string taxdepartment,
    string taxnumber,
    string city,
    string town,
    string fulladdress) : IRequest<Result<bool>>;
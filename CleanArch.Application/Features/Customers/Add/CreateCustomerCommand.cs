using MediatR;
using TS.Result;

namespace CleanArch.Application.Features.Customers.Add;

public sealed record CreateCustomerCommand(
    string name,
    string taxdepartment,
    string taxnumber,
    string city,
    string town,
    string fulladdress) : IRequest<Result<bool>>;
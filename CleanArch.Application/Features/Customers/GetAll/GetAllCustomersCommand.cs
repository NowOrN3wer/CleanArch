using CleanArch.Domain.Entities;
using MediatR;
using TS.Result;

namespace CleanArch.Application.Features.Customers.GetAll;

public sealed record GetAllCustomersCommand : IRequest<Result<List<Customer>>>;
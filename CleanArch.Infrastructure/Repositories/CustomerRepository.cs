using CleanArch.Domain.Entities;
using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure.Context;
using GenericRepository;

namespace CleanArch.Infrastructure.Repositories;

internal sealed class CustomerRepository(ApplicationDbContext context)
    : Repository<Customer, ApplicationDbContext>(context), ICustomerRepository;
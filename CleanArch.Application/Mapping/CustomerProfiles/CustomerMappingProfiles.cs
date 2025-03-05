using AutoMapper;
using CleanArch.Application.Features.Customers.Add;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mapping.CustomerProfiles;

public class CustomerMappingProfiles : Profile
{
    public CustomerMappingProfiles()
    {
        CreateMap<CreateCustomerCommand, Customer>();
    }
}
using AutoMapper;
using Watchdog.Backend.Application.Features.Customers;
using Watchdog.Backend.Application.Features.Customers.Commands.RegisterCustomer;
using Watchdog.Backend.Application.Features.Customers.Queries.GetCustomerDetail;
using Watchdog.Backend.Application.Features.Customers.Queries.GetCustomersList;
using Watchdog.Backend.Domain.Entities;

namespace Watchdog.Backend.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerListDto>();
        CreateMap<Customer, CustomerDetailDto>();
        
        CreateMap<CustomerRegisterDto, RegisterCustomerCommand>();
        CreateMap<RegisterCustomerCommand, Customer>();
    }
}
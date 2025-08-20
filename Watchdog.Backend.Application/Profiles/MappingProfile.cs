using AutoMapper;
using Watchdog.Backend.Application.Contracts.Features.Customers;
using Watchdog.Backend.Domain.Entities;

namespace Watchdog.Backend.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerListDto>();
        CreateMap<Customer, CustomerDetailDto>();
    }
}
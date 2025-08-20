using AutoMapper;
using MediatR;
using Watchdog.Backend.Application.Contracts.Persistence;

namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomersList;

public class GetCustomersListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<GetCustomersListQuery, List<CustomerListDto>>
{
    public async Task<List<CustomerListDto>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
    {
        var customers = await customerRepository.GetAllAsync();
        return mapper.Map<List<CustomerListDto>>(customers);
    }
}
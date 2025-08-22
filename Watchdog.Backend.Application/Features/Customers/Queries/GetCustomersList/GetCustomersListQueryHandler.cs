using AutoMapper;
using MediatR;
using Watchdog.Backend.Application.Contracts.Persistence;

namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomersList;

public class GetCustomersListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    : IRequestHandler<GetCustomersListQuery, GetCustomersListQueryResponse>
{
    public async Task<GetCustomersListQueryResponse> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
    {
        var customers = await customerRepository.GetAllAsync();
        
        return new GetCustomersListQueryResponse
        {
            Success = true,
            Customers = mapper.Map<List<CustomerListDto>>(customers)
        };
    }
}
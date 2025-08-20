using MediatR;

namespace Watchdog.Backend.Application.Contracts.Features.Customers.Queries.GetCustomersList;

public class GetCustomersListQuery : IRequest<List<CustomerListDto>>
{
    
}
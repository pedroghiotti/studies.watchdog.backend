using MediatR;

namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomersList;

public class GetCustomersListQuery : IRequest<List<CustomerListDto>>
{
    
}
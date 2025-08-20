using MediatR;

namespace Watchdog.Backend.Application.Contracts.Features.Customers;

public class GetCustomersListQuery : IRequest<List<CustomerListDto>>
{
    
}
using MediatR;

namespace Watchdog.Backend.Application.Contracts.Features.Customers;

public class GetCustomerDetailQuery : IRequest<CustomerDetailDto>
{
    public Guid CustomerId { get; set; }
}
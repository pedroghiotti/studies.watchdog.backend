using MediatR;

namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomerDetail;

public class GetCustomerDetailQuery : IRequest<CustomerDetailDto>
{
    public Guid CustomerId { get; set; }
}
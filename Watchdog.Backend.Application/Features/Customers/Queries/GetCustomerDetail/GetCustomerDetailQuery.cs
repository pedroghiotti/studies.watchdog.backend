using MediatR;

namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomerDetail;

public class GetCustomerDetailQuery : IRequest<GetCustomerDetailQueryResponse>
{
    public required Guid CustomerId { get; set; }
}
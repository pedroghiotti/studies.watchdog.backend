using Watchdog.Backend.Application.Responses;

namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomerDetail;

public class GetCustomerDetailQueryResponse : BaseResponse
{
    public CustomerDetailDto? Customer { get; set; }
}
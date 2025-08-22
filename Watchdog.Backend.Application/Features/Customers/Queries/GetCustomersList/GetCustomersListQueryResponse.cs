using Watchdog.Backend.Application.Responses;

namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomersList;

public class GetCustomersListQueryResponse : BaseResponse
{
    public required List<CustomerListDto> Customers { get; set; }
}
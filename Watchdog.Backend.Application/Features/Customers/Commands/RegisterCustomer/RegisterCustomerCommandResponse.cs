using Watchdog.Backend.Application.Features.Customers.Queries.GetCustomerDetail;
using Watchdog.Backend.Application.Responses;

namespace Watchdog.Backend.Application.Features.Customers.Commands.RegisterCustomer;

public class RegisterCustomerCommandResponse : BaseResponse
{
    public CustomerDetailDto? Customer { get; set; }
}
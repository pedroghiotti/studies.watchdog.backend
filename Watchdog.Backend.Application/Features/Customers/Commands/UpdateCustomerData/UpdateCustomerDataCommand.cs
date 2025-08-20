using MediatR;

namespace Watchdog.Backend.Application.Features.Customers.Commands.UpdateCustomerData;

public class UpdateCustomerDataCommand : IRequest
{
    public required Guid CustomerId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
}
using MediatR;

namespace Watchdog.Backend.Application.Contracts.Features.Customers.Commands.RegisterCustomer;

public class RegisterCustomerCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
}
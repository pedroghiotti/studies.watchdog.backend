namespace Watchdog.Backend.Application.Features.Customers.Commands.RegisterCustomer;

public class CustomerRegisterDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
}
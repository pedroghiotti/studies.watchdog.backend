namespace Watchdog.Backend.Application.Contracts.Features.Customers.Commands.UpdateCustomerData;

public class CustomerUpdateDataDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
}
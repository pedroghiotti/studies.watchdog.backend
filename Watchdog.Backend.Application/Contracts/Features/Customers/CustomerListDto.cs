namespace Watchdog.Backend.Application.Contracts.Features.Customers;

public class CustomerListDto
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
}
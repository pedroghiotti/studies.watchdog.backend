namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomersList;

public class CustomerListDto
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
}
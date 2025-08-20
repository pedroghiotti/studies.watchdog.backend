namespace Watchdog.Backend.Application.Features.Customers.Queries.GetCustomerDetail;

public class CustomerDetailDto
{
    public Guid CustomerId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
using Watchdog.Backend.Domain.Common;

namespace Watchdog.Backend.Domain.Entities;

public class Customer : AuditableEntity
{
    public Guid CustomerId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    
    public ICollection<Tag>? Tags { get; set; } = new List<Tag>();
    
    public ICollection<Pet>? Pets { get; set; } = new List<Pet>();
}
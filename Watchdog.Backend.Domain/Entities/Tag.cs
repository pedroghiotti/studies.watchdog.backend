using Watchdog.Backend.Domain.Common;

namespace Watchdog.Backend.Domain.Entities;

public class Tag : AuditableEntity
{
    public Guid TagId { get; set; }
    
    public Pet? Pet { get; set; }
    public Guid? PetId { get; set; }
    
    public Customer? Owner { get; set; }
    public Guid? OwnerId { get; set; }
}
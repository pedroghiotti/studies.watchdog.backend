using Watchdog.Backend.Domain.Common;

namespace Watchdog.Backend.Domain.Entities;

public class Pet : AuditableEntity
{
    public Guid PetId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    
    public Tag? Tag { get; set; }
    public Guid? TagId { get; set; }
    
    public Customer? Owner { get; set; }
    public Guid? OwnerId { get; set; }
}
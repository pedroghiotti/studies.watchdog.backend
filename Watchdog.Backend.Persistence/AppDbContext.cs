using Microsoft.EntityFrameworkCore;
using Watchdog.Backend.Domain.Common;
using Watchdog.Backend.Domain.Entities;

namespace Watchdog.Backend.Persistence;

public class AppDbContext (DbContextOptions<AppDbContext> options)
    : DbContext (options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Pet> Pets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastUpdatedAt = DateTime.UtcNow;
                    break;
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }
}
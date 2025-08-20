using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Watchdog.Backend.Domain.Entities;

namespace Watchdog.Backend.Persistence.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(p => p.PetId);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Type).IsRequired();
        builder.Property(p => p.DateOfBirth).IsRequired();
        
        builder.HasOne(p => p.Tag)
            .WithOne()
            .HasForeignKey<Pet>(p => p.TagId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Owner)
            .WithMany(c => c.Pets)
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
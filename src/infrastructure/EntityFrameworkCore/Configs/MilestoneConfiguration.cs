using domain.models.milestone;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.configs;

public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
{
    public void Configure(EntityTypeBuilder<Milestone> builder)
    {
        // * Many-to-Many: Milestone (Many) to WorkItems (Many)
        builder
            .HasMany(m => m.WorkItems)
            .WithMany()
            .UsingEntity(j => j.ToTable("MilestoneWorkItems"));
    }
}
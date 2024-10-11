using domain.models.iteration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.configs;

public class IterationConfiguration : IEntityTypeConfiguration<Iteration>
{
    public void Configure(EntityTypeBuilder<Iteration> builder)
    {
        builder
            .HasMany(i => i.WorkItems)
            .WithMany()
            .UsingEntity(j => j.ToTable("IterationWorkItems"));
    }
}
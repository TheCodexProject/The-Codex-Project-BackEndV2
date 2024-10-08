using domain.models.project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.configs;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        // # WORKITEMS CONFIGURATION
        builder.HasMany(p => p.WorkItems)
            .WithOne() // Assuming WorkItem has a property like ProjectId for the foreign key
            .HasForeignKey("Project")
            .OnDelete(DeleteBehavior.Cascade);

        // # ITERATIONS CONFIGURATION
        builder.HasMany(p => p.Iterations)
            .WithOne() // Assuming Iteration has a property like ProjectId for the foreign key
            .HasForeignKey("Project")
            .OnDelete(DeleteBehavior.Cascade);

        // # BOARDS CONFIGURATION
        builder.HasMany(p => p.Boards)
            .WithOne() // Assuming Board has a property like ProjectId for the foreign key
            .HasForeignKey("Project")
            .OnDelete(DeleteBehavior.Cascade);

        // # MILESTONES CONFIGURATION
        builder.HasMany(p => p.Milestones)
            .WithOne() // Assuming Milestone has a property like ProjectId for the foreign key
            .HasForeignKey("Project")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
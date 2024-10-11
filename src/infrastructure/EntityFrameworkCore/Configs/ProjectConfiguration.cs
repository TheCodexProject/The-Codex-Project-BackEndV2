using domain.models.project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.configs;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        // * Many-to-One: Project (Many) to Workspace (1)
        builder
            .HasOne(p => p.Workspace)
            .WithMany(w => w.Projects)
            .HasForeignKey("WorkspaceUid")
            .OnDelete(DeleteBehavior.Cascade);

        // * Many-to-One: Project (Many) to WorkItem (1)
        builder
            .HasMany(p => p.WorkItems)
            .WithOne()
            .HasForeignKey("ProjectUid")
            .OnDelete(DeleteBehavior.Cascade);

        // * Many-to-One: Project (1) to Iterations (Many)
        builder
            .HasMany(p => p.Iterations)
            .WithOne()
            .HasForeignKey("ProjectUid")
            .OnDelete(DeleteBehavior.Cascade);

        // * Many-to-One: Project (1) to Boards (Many)
        builder
            .HasMany(p => p.Boards)
            .WithOne()
            .HasForeignKey("ProjectUid")
            .OnDelete(DeleteBehavior.Cascade);

        // * Many-to-One: Project (1) to Milestones (Many)
        builder
            .HasMany(p => p.Milestones)
            .WithOne()
            .HasForeignKey("ProjectUid")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
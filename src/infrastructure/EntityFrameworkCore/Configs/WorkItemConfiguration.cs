using domain.models;
using domain.models.resource;
using domain.models.workitem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.configs;

public class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
{
    /// <summary>
    /// Used for defining the relationships that the work item has with other entities.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<WorkItem> builder)
    {
        // * Many-to-one: Work Item (Many) to Users (1)
        builder
            .HasOne(w => w.AssignedTo)
            .WithMany() // Assuming a User can have multiple WorkItems assigned
            .HasForeignKey(w => w.AssignedToId)
            .OnDelete(DeleteBehavior.Restrict);

        // * Many-to-one: SubItems (Many) to Work Item (1)
        builder
            .HasOne(w => w.Parent)
            .WithMany(w => w.SubItems)
            .HasForeignKey(w => w.ParentId)
            .OnDelete(DeleteBehavior.Restrict); // You can use Cascade or Restrict depending on your requirements

        // * Many-to-many: Work Item (Many) to (Many) Resources
        builder
            .HasMany(w => w.Resources)
            .WithMany()
            .UsingEntity(j => j.ToTable("WorkItemResources"));

        // * Many-to-many: Work Item (Many) to (Many) Dependencies
        builder
            .HasMany(w => w.Dependencies)
            .WithMany()
            .UsingEntity(j => j.ToTable("WorkItemDependencies"));
    }
    
}
using domain.models;
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
        // # ASSIGNEE
        builder
            .HasOne(w => w.AssignedTo)
            .WithMany() // Assuming a User can have multiple WorkItems assigned
            .HasForeignKey(w => w.AssignedToId)
            .OnDelete(DeleteBehavior.Restrict);

        // # SUB-ITEMS
        builder
            .HasOne(w => w.Parent)
            .WithMany(w => w.SubItems)
            .HasForeignKey(w => w.ParentId)
            .OnDelete(DeleteBehavior.Restrict); // You can use Cascade or Restrict depending on your requirements

        // # GuidListComparer (Used for the Resources and Dependencies)
        var guidListComparer = new ValueComparer<List<Guid>>(
            (c1, c2) => c1.SequenceEqual(c2), // Compare sequences for equality
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Calculate a hash code for the list
            c => c.ToList() // Deep copy the list to avoid reference issues
        );


        // # Resources
        builder
            .Property(w => w.ResourcesIds)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Guid.Parse)
                    .ToList())
            .Metadata.SetValueComparer(guidListComparer);

        // # Dependencies
        builder
            .Property(w => w.DependenciesIds)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Guid.Parse)
                    .ToList())
            .Metadata.SetValueComparer(guidListComparer);
    }
    
}
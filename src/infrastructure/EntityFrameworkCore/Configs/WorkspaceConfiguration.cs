using domain.interfaces;
using domain.models.workspace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.configs;


public class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        // # GUID LIST COMPARER
        var guidListComparer = new ValueComparer<List<Guid>>(
            (c1, c2) => c1.SequenceEqual(c2), // Compare sequences for equality
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Calculate a hash code for the list
            c => c.ToList() // Deep copy the list to avoid reference issues
        );

        // # PROJECTS
        builder.Property(w => w.Projects)
            .HasConversion(
                v => string.Join(',', v),             // Convert List<Guid> to a comma-separated string for storage
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Guid.Parse)
                    .ToList())                      // Convert string back to List<Guid>
            .Metadata.SetValueComparer(guidListComparer); // Add a value comparer

        // # CONTACTS
        builder.Property(w => w.Contacts)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Guid.Parse)
                    .ToList())
            .Metadata.SetValueComparer(guidListComparer);

        // # RESOURCES
        builder.Property(w => w.Resources)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Guid.Parse)
                    .ToList())
            .Metadata.SetValueComparer(guidListComparer);
    }
}
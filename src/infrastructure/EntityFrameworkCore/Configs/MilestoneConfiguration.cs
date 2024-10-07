using domain.models.milestone;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Configs;

public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
{
    public void Configure(EntityTypeBuilder<Milestone> builder)
    {
        // # GuidListComparer (Used for the Work items)
        var guidListComparer = new ValueComparer<List<Guid>>(
            (c1, c2) => c1.SequenceEqual(c2), // Compare sequences for equality
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Calculate a hash code for the list
            c => c.ToList() // Deep copy the list to avoid reference issues
        );

        // # Work items
        builder
            .Property(w => w.WorkItems)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Guid.Parse)
                    .ToList())
            .Metadata.SetValueComparer(guidListComparer);
    }
}
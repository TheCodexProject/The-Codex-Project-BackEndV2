using domain.models;
using domain.models.organisation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Configs;

public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
{
    public void Configure(EntityTypeBuilder<Organisation> builder)
    {
        // # GuidListComparer (Used for the Resources and Dependencies)
        var guidListComparer = new ValueComparer<List<Guid>>(
            (c1, c2) => c1.SequenceEqual(c2), // Compare sequences for equality
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Calculate a hash code for the list
            c => c.ToList() // Deep copy the list to avoid reference issues
        );


        // # Resources
        builder
            .Property(w => w.Owners)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Guid.Parse)
                    .ToList())
            .Metadata.SetValueComparer(guidListComparer);

        // # Dependencies
        builder
            .Property(w => w.Resources)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(Guid.Parse)
                    .ToList())
            .Metadata.SetValueComparer(guidListComparer);
    }
    
}
using domain.models.organization;
using domain.models.user;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.configs;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        // * Many-to-Many: Organization (Many) to User (Many)
        builder
            .HasMany(o => o.Owners)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "OrganizationOwners",
                r => r.HasOne<User>().WithMany().HasForeignKey("UserUid"),
                l => l.HasOne<Organization>().WithMany().HasForeignKey("OrganizationUid")
            );

        // * One-to-Many: Organization (1) to Resource (Many)
        builder
            .HasMany(o => o.Resources)
            .WithOne()
            .HasForeignKey(r => r.OrganizationUid)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}
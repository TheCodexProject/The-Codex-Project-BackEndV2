using domain.models.board;
using domain.models.board.values;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Configs;

public class FilterCriteriaConfiguration : IEntityTypeConfiguration<FilterCriteria>
{
    public void Configure(EntityTypeBuilder<FilterCriteria> builder)
    {
        builder.HasOne<Board>()
            .WithMany(b => b.FilterCriterias)
            .HasForeignKey(oc => oc.BoardUid); // Foreign key to Board
    }
}
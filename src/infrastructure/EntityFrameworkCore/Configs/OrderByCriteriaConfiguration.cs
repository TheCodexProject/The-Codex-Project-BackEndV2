using domain.models.board;
using domain.models.board.values;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Configs;

public class OrderByCriteriaConfiguration : IEntityTypeConfiguration<OrderByCriteria>
{
    public void Configure(EntityTypeBuilder<OrderByCriteria> builder)
    {
        builder.HasOne<Board>()
            .WithMany(b => b.OrderByCriterias)
            .HasForeignKey(oc => oc.BoardUid); // Foreign key to Board
    }
}
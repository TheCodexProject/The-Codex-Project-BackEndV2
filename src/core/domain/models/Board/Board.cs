

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.models.board.values;

namespace domain.models.board;

public class Board
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    [ForeignKey("Project")]
    public Guid ProjectUid { get; private set; }

    [MaxLength(75)]
    [MinLength(3)]
    [Required]
    public string? Title { get; private set; }

    public List<FilterCriteria> FilterCriterias { get; private set; } = [];

    public List<OrderByCriteria> OrderByCriterias { get; private set; } = [];

    private Board()
    {
        Uid = Guid.NewGuid();
    }

    public static Board Create()
    {
        // ! No validation needed here
        // As the Board is to be modified through the provided methods.
        return new Board();
    }

    // TODO: Implement update methods for the Board (e.g. UpdateTitle, AddFilter, AddOrderByExpression, etc...)
}
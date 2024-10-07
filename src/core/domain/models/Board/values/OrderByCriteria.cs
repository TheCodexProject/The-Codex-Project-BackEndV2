using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.models.board.values;

public class OrderByCriteria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    [ForeignKey("BoardUid")]
    public Guid BoardUid { get; private set; }

    [Required]
    public string PropertyName { get; set; }

    [Required]
    public bool IsAscending { get; set; }
}

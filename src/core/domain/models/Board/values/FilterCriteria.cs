using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.models.board.values;

public class FilterCriteria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    [ForeignKey("BoardUid")]
    public Guid BoardUid { get; private set; }

    [Required]
    public string PropertyName { get; set; }

    [Required]
    public string Operator { get; set; } // e.g., "Equals", "Contains", etc.

    [Required]
    public string Value { get; set; }
}
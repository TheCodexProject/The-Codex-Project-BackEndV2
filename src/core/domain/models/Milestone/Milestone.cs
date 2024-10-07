using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.models.milestone;

public class Milestone
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    [MaxLength(75)]
    [MinLength(3)]
    [Required]
    public string? Title { get; private set; }

    public List<Guid> WorkItems { get; private set; } = [];

    private Milestone()
    {
        Uid = Guid.NewGuid();
    }

    public static Milestone Create()
    {
        // ! No validation needed here
        // As the Milestone is to be modified through the provided methods.
        return new Milestone();
    }

    // TODO: Add the updates methods for the Milestone. (e.g. UpdateTitle, AddWorkItems, RemoveItems, etc.)
}
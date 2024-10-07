using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.models.iteration;

public class Iteration
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

    public List<Guid> WorkItems { get; private set; } = [];

    private Iteration()
    {
        Uid = Guid.NewGuid();
    }

    public static Iteration Create()
    {
        // ! No validation needed here
        // As the Iteration is to be modified through the provided methods.
        return new Iteration();
    }

    // TODO: Add the updates methods for the Iteration. (e.g. UpdateTitle, AddWorkItems, RemoveItems, etc.)
}
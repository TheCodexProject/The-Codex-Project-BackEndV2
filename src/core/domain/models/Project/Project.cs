using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.models.project.values;
using domain.models.values;

namespace domain.models.project;

public class Project
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid  { get; private set; }

    [MaxLength(75)]
    [MinLength(3)]
    [Required]
    public string? Title { get; private set; }

    [MaxLength(500)]
    public string? Description { get; private set; }

    public DateTime? StartTime { get; private set; }

    public DateTime? EndTime { get; private set; }

    public Framework? Framework { get; private set; }

    public Status? Status { get; private set; }

    public Priority? Priority { get; private set; }

    private Project()
    {
        // "Specific" values
        Uid = Guid.NewGuid();
    }

    public static Project Create()
    {
        // ! No validation needed here
        // As the Project is to be modified through the provided methods.
        return new Project();
    }
}
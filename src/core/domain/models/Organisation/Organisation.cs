using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.interfaces;

namespace domain.models.organisation;

public class Organisation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    [MaxLength(100)]
    [MinLength(2)]
    [Required]
    public string? Name { get; private set; }

    public List<Guid> Owners { get; set; } = [];

    public List<Guid> Resources { get; set; } = [];

    private Organisation()
    {
        Uid = Guid.NewGuid();
    }

    public static Organisation Create()
    {
        // ! No validation needed here
        // As the organisation is to be modified through the provided methods.
        return new Organisation();
    }

    // TODO: Add methods to update the organisation. (e.g. UpdateName, AddOwner, RemoveOwner, AddResource, RemoveResource etc...)
}
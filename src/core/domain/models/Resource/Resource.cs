using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.models;

public class Resource
{
    /// <summary>
    /// The unique identifier of the resource.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    /// <summary>
    /// Title of the resource.
    /// </summary>
    [MaxLength(75)]
    [MinLength(3)]
    [Required]
    public string? Title { get; private set; }

    /// <summary>
    /// Format of the resource.
    /// </summary>
    [MaxLength(10)]
    [MinLength(2)]
    [Required]
    public string? Format { get; private set; }

    /// <summary>
    /// Stores the content of the resource.
    /// </summary>
    [Required]
    public string? Content { get; private set; }

    /// <summary>
    /// The private constructor for the <see cref="Resource"/> class.
    /// </summary>
    private Resource()
    {
        Uid = Guid.NewGuid();
    }

    /// <summary>
    /// Constructs a new instance of <see cref="Resource"/>.
    /// </summary>
    /// <returns></returns>
    public static Resource Create()
    {
        return new Resource();
    }

    // TODO: Add methods to update the resource's properties. (e.g. UpdateTitle, UpdateFormat, UpdateContent)
}
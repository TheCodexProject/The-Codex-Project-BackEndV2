using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OperationResult;

namespace domain.models.resource;

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
    [MaxLength(200)]
    public string? Reference { get; private set; }

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

    public Result UpdateTitle(string title)
    {
        var result = ResourceValidator.ValidateTitle(title);

        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        Title = title;

        return Result.Success();
    }

    public Result UpdateFormat(string format)
    {
        var result = ResourceValidator.ValidateFormat(format);

        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        Format = format;

        return Result.Success();
    }

    public Result UpdateReference(string reference)
    {
        var result = ResourceValidator.ValidateReference(reference);

        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        Reference = reference;

        return Result.Success();
    }

}
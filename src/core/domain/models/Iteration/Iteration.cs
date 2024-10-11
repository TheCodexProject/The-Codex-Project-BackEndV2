using OperationResult;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.models.workitem;

namespace domain.models.iteration;

public class Iteration
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    [ForeignKey("ProjectUid")]
    public Guid ProjectUid { get; private set; }

    [MaxLength(75)]
    [MinLength(3)]
    [Required]
    public string? Title { get; private set; }

    public virtual List<WorkItem> WorkItems { get; private set; } = [];

    /// <summary>
    /// Private constructor for the <see cref="Iteration"/> class to prevent direct instantiation.
    /// </summary>
    private Iteration()
    {
        Uid = Guid.NewGuid();
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Iteration"/> class.
    /// </summary>
    /// <returns>A new <see cref="Iteration"/> instance.</returns>
    public static Iteration Create()
    {
        // No validation needed here as the Iteration is to be modified through the provided methods.
        return new Iteration();
    }

    /// <summary>
    /// Updates the title of the Iteration.
    /// </summary>
    /// <param name="title">The new title to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was successful or a failure.</returns>
    public Result UpdateTitle(string title)
    {
        // Validate the input.
        var result = IterationValidator.ValidateTitle(title);

        // Return failure if validation fails.
        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        // Update the title and return success.
        Title = result.Value;
        return Result.Success();
    }

    /// <summary>
    /// Adds a work item to the Iteration.
    /// </summary>
    /// <param name="workItem">The unique identifier of the work item to be added.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was successful or a failure.</returns>
    public Result AddWorkItem(WorkItem workItem)
    {
        // Validate the input.
        var result = IterationValidator.ValidateAddWorkItem(workItem, WorkItems);

        // Return failure if validation fails.
        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        // Add the work item and return success.
        WorkItems.Add(result);
        return Result.Success();
    }

    /// <summary>
    /// Removes a work item from the Iteration.
    /// </summary>
    /// <param name="workItem">The unique identifier of the work item to be removed.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was successful or a failure.</returns>
    public Result RemoveWorkItem(WorkItem workItem)
    {
        // Validate the input.
        var result = IterationValidator.ValidateRemoveWorkItem(workItem, WorkItems);

        // Return failure if validation fails.
        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        // Remove the work item and return success.
        WorkItems.Remove(result);
        return Result.Success();
    }
}
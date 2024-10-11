using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.models.user;
using domain.models.workitem;
using OperationResult;

namespace domain.models.milestone;

public class Milestone
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
    /// Private constructor for the <see cref="Milestone"/> class.
    /// </summary>
    private Milestone()
    {
        Uid = Guid.NewGuid();
    }

    /// <summary>
    /// Constructor for the <see cref="Milestone"/> class.
    /// </summary>
    /// <returns></returns>
    public static Milestone Create()
    {
        // ! No validation needed here
        // As the Milestone is to be modified through the provided methods.
        return new Milestone();
    }

    /// <summary>
    /// Updates the title of the milestone.
    /// </summary>
    /// <param name="title">Title to be set.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result UpdateTitle(string title, User? modifiedBy = null)
    {
        // ! Validate the title.
        var result = MilestoneValidator.ValidateTitle(title);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the title.
        Title = title;

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        return Result.Success();
    }

    /// <summary>
    /// Adds a work item to the milestone.
    /// </summary>
    /// <param name="workItem">Work item to be added.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result AddWorkItem(WorkItem? workItem, User? modifiedBy = null)
    {
        // ! Validate the sub item.
        var result = MilestoneValidator.ValidateAddWorkItem(workItem, WorkItems);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Add the sub item.
        // The sub item is not null, so we can safely add it.
        WorkItems.Add(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        return Result.Success();
    }

    /// <summary>
    /// Removes a work item from the milestone.
    /// </summary>
    /// <param name="workItem">Work item to be removed.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result RemoveWorkItem(WorkItem? workItem, User? modifiedBy = null)
    {
        // ! Validate the sub item.
        var result = MilestoneValidator.ValidateRemoveWorkItem(workItem, WorkItems);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the sub item.
        // The sub item is not null, so we can safely remove it.
        WorkItems.Remove(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        return Result.Success();
    }
}
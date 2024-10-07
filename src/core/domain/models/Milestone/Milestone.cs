using domain.models.Milestone;
using domain.models.user;
using domain.models.workitem;
using OperationResult;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.models.milestone;

public class Milestone
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    #region Metadata

    /// <summary>
    /// The creator of the work item.
    /// </summary>
    [MaxLength(300)]
    private string? CreatedBy { get; set; }

    /// <summary>
    /// When the work item was created.
    /// </summary>
    private DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The last user that updated the work item.
    /// </summary>
    [MaxLength(300)]
    private string? UpdatedBy { get; set; }

    /// <summary>
    /// When the work item was last updated.
    /// </summary>
    private DateTime? UpdatedAt { get; set; }

    #endregion

    #region Fields
    [MaxLength(75)]
    [MinLength(3)]
    [Required]
    public string? Title { get; private set; }

    public string? Content { get; private set; }

    #endregion

    #region Relations

    /// <summary>
    /// Navigation property for the sub items of the WorkItem.
    /// </summary>
    public List<WorkItem> WorkItems { get; private set; } = [];

    #endregion

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

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Updates the content of the milestone.
    /// </summary>
    /// <param name="content">Content to be set.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result UpdateContent(string title, User? modifiedBy = null)
    {
        // ! Validate the title.
        var result = MilestoneValidator.ValidateContent(title);

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

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Adds a work item to the milestone.
    /// </summary>
    /// <param name="subItem">Work item to be added.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result AddSubItem(WorkItem? workItem, User? modifiedBy = null)
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
        WorkItems.Add(workItem);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Removes a work item from the milestone.
    /// </summary>
    /// <param name="subItem">Work item to be removed.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result RemoveSubItem(WorkItem? subItem, User? modifiedBy = null)
    {
        // ! Validate the sub item.
        var result = MilestoneValidator.ValidateRemoveWorkItem(subItem, WorkItems);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the sub item.
        // The sub item is not null, so we can safely remove it.
        WorkItems.Remove(subItem);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }
}
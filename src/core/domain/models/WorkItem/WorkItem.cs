using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.models.resource;
using domain.models.user;
using domain.models.values;
using OperationResult;

namespace domain.models.workitem;

public class WorkItem
{
    /// <summary>
    /// The unique identifier of the WorkItem.
    /// </summary>
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

    /// <summary>
    /// Title of the work item.
    /// </summary>
    [MaxLength(75)]
    [MinLength(3)]
    [Required]
    public string? Title { get; set; }

    /// <summary>
    /// Description of the work item.
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }

    /// <summary>
    /// The type of the work item.
    /// </summary>
    [MaxLength(20)]
    public ItemType? Type { get; set; }

    /// <summary>
    /// The status of the work item.
    /// </summary>
    public Status? Status { get; set; }

    /// <summary>
    /// The priority of the work item.
    /// </summary>
    public Priority? Priority { get; set; }

    /// <summary>
    /// The ID of the user that the work item is assigned to.
    /// </summary>
    [ForeignKey("AssignedTo")]
    public Guid? AssignedToId { get; private set; }

    /// <summary>
    /// The user that the work item is assigned to.
    /// (Lazy loaded)
    /// </summary>
    public virtual User? AssignedTo { get; private set; }

    #endregion

    #region Relations

    [ForeignKey("ProjectUid")]
    public Guid ProjectUid { get; private set; }

    /// <summary>
    /// The unique identifier of the parent WorkItem, if any.
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// Reference to the parent WorkItem, if any.
    /// (Lazy loaded)
    /// </summary>
    [ForeignKey("ParentId")]
    public virtual WorkItem? Parent { get; private set; }

    /// <summary>
    /// Navigation property for the sub items of the WorkItem.
    /// (Lazy loaded)
    /// </summary>
    public virtual List<WorkItem> SubItems { get; private set; } = [];

    /// <summary>
    /// The unique identifiers of the resources that are attached to the work item.
    /// (Lazy loaded)
    /// </summary>
    public virtual List<Resource> Resources { get; private set; } = [];

    /// <summary>
    /// The unique identifiers of the dependencies of the work item.
    /// (Lazy loaded)
    /// </summary>
    public virtual List<WorkItem> Dependencies { get; private set; } = [];

    #endregion

    /// <summary>
    /// Private constructor for the <see cref="WorkItem"/> class.
    /// </summary>
    private WorkItem()
    {
        Uid = Guid.NewGuid();
    }

    /// <summary>
    /// Constructs a new instance of <see cref="WorkItem"/>.
    /// </summary>
    /// <returns></returns>
    public static WorkItem Create()
    {
        return new WorkItem();
    }

    /// <summary>
    /// Updates the title of the work item.
    /// </summary>
    /// <param name="title">Title to be set.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result UpdateTitle(string title, User? modifiedBy = null)
    {
        // ! Validate the title.
        var result = WorkItemValidator.ValidateTitle(title);

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
    /// Updates the description of the work item.
    /// </summary>
    /// <param name="description">Description to be set.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>w
    public Result UpdateDescription(string description, User? modifiedBy = null)
    {
        // ! Validate the description.
        var result = WorkItemValidator.ValidateDescription(description);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the description.
        Description = description;

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Updates the status of the work item.
    /// </summary>
    /// <param name="status">Status to be set.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result UpdateStatus(Status status, User? modifiedBy = null)
    {
        // ! Validate the status.
        var result = WorkItemValidator.ValidateStatus(status);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the status.
        Status = status;

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Updates the priority of the work item.
    /// </summary>
    /// <param name="priority">Priority to be set.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result UpdatePriority(Priority priority, User? modifiedBy = null)
    {
        // ! Validate the priority.
        var result = WorkItemValidator.ValidatePriority(priority);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the priority.
        Priority = priority;

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Updates the type of the work item.
    /// </summary>
    /// <param name="type">Type to be set.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result UpdateType(ItemType type, User? modifiedBy = null)
    {
        // ! Validate the type.
        var result = WorkItemValidator.ValidateType(type);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the type.
        Type = type;

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Assigns the work item to a user.
    /// </summary>
    /// <param name="user">User to be assigned</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result AssignTo(User user, User? modifiedBy = null)
    {
        // ! Validate the user.
        var result = WorkItemValidator.ValidateAssignee(user);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Assign the user.
        AssignedTo = user;

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Adds a sub item to the work item.
    /// </summary>
    /// <param name="subItem">Sub item to be added.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result AddSubItem(WorkItem? subItem, User? modifiedBy = null)
    {
        // ! Validate the sub item.
        var result = WorkItemValidator.ValidateAddSubItem(subItem, SubItems);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Add the sub item.
        // The sub item is not null, so we can safely add it.
        SubItems.Add(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Removes a sub item from the work item.
    /// </summary>
    /// <param name="subItem">Sub item to be removed.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result RemoveSubItem(WorkItem? subItem, User? modifiedBy = null)
    {
        // ! Validate the sub item.
        var result = WorkItemValidator.ValidateRemoveSubItem(subItem, SubItems);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the sub item.
        // The sub item is not null, so we can safely remove it.
        SubItems.Remove(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Adds a resource to the work item.
    /// </summary>
    /// <param name="resource">Resource to be added.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result AddResource(Resource? resource, User? modifiedBy = null)
    {
        // ! Validate the resource.
        var result = WorkItemValidator.ValidateAddResource(resource, Resources);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Add the resource.
        Resources.Add(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Removes a resource from the work item.
    /// </summary>
    /// <param name="resource">Resource to be removed.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result RemoveResource(Resource? resource, User? modifiedBy = null)
    {
        // ! Validate the resource.
        var result = WorkItemValidator.ValidateRemoveResource(resource, Resources);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the resource.
        Resources.Remove(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Adds a dependency to the work item.
    /// </summary>
    /// <param name="dependency">Dependency to be added.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result AddDependency(WorkItem? dependency, User? modifiedBy = null)
    {
        // ! Validate the dependency.
        var result = WorkItemValidator.ValidateAddDependency(dependency, Dependencies);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Add the dependency.
        Dependencies.Add(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Removes a dependency from the work item.
    /// </summary>
    /// <param name="dependency">Dependency to be removed.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result RemoveDependency(WorkItem? dependency, User? modifiedBy = null)
    {
        // ! Validate the dependency.
        var result = WorkItemValidator.ValidateRemoveDependency(dependency, Dependencies);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the dependency.
        Dependencies.Remove(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }
}
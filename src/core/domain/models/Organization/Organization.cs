using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.models.resource;
using domain.models.user;
using OperationResult;

namespace domain.models.organization;

public class Organization
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

    [MaxLength(100)]
    [MinLength(2)]
    [Required]
    public string? Name { get; private set; }

    #endregion

    #region Relations

    /// <summary>
    /// The owners of the organisation.
    /// (Lazy loaded)
    /// </summary>
    public virtual List<User> Owners { get; private set; } = [];

    /// <summary>
    /// The resources of the organisation.
    /// (Lazy loaded)
    /// </summary>
    public virtual List<Resource> Resources { get; private set; } = [];

    #endregion

    /// <summary>
    /// Private constructor for the <see cref="Organization"/> class.
    /// </summary>
    private Organization()
    {
        Uid = Guid.NewGuid();
    }

    /// <summary>
    /// Constructor for the <see cref="Organization"/> class.
    /// </summary>
    /// <returns></returns>
    public static Organization Create()
    {
        // ! No validation needed here
        // As the organisation is to be modified through the provided methods.
        return new Organization();
    }

    /// <summary>
    /// Updates the name of the organisation.
    /// </summary>
    /// <param name="name">Title to be set.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result UpdateTitle(string name, User? modifiedBy = null)
    {
        // ! Validate the title.
        var result = OrganizationValidator.ValidateName(name);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the title.
        Name = name;

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Adds a owner to the organisation.
    /// </summary>
    /// <param name="owner">Owner to be added.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result AddOwner(User? owner, User? modifiedBy = null)
    {
        // ! Validate the owner.
        var result = OrganizationValidator.ValidateAddOwner(owner, Owners);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Add the owner.
        // The owner is not null, so we can safely add it.
        Owners.Add(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Removes an owner from the organisation.
    /// </summary>
    /// <param name="owner">Owner to be added.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result RemoveOwner(User? owner, User? modifiedBy = null)
    {
        // ! Validate the Owner.
        var result = OrganizationValidator.ValidateRemoveOwner(owner, Owners);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the Owner.
        // The Owner is not null, so we can safely remove it.
        Owners.Remove(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Adds a resource to the organisation.
    /// </summary>
    /// <param name="resource">Resource to be added.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result AddResource(Resource? resource, User? modifiedBy = null)
    {
        // ! Validate the resource.
        var result = OrganizationValidator.ValidateAddResource(resource, Resources);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Add the resource.
        // The resource is not null, so we can safely add it.
        Resources.Add(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    /// <summary>
    /// Removes a resource from the organisation.
    /// </summary>
    /// <param name="resource">Resource to be added.</param>
    /// <param name="modifiedBy">The user who made the update.</param>
    /// <returns></returns>
    public Result RemoveResource(Resource? resource, User? modifiedBy = null)
    {
        // ! Validate the resource.
        var result = OrganizationValidator.ValidateRemoveResource(resource, Resources);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            // ! Return the failure.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Remove the resource.
        // The resource is not null, so we can safely remove it.
        Resources.Remove(result);

        // ? Is modified by a user?
        if (modifiedBy == null) return Result.Success();

        // * Update the metadata.
        UpdatedBy = modifiedBy.Email;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }
}
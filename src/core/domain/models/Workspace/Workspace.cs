using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.exceptions.common;
using domain.exceptions.models.Workspace;
using domain.models.project;
using domain.models.resource;
using domain.models.user;
using domain.models.workspace.values;
using OperationResult;

namespace domain.models.workspace;

public class Workspace
{
    /// <summary>
    ///  The unique identifier for the Workspace.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    #region  Fields

    /// <summary>
    /// The unique identifier for the Owner.
    /// </summary>
    public Guid Owner { get; private set; }

    /// <summary>
    /// The type of the Owner. Either an Organization or a User.
    /// </summary>
    public OwnerType OwnerType { get; private set; }

    /// <summary>
    /// The title of the Workspace.
    /// </summary>
    [MaxLength(100)]
    [MinLength(3)]
    [Required]
    public string? Title { get; private set; }


    #endregion

    #region Relations

    /// <summary>
    /// The list of projects within the Workspace.
    /// (Lazy Loaded)
    /// </summary>
    public virtual List<Project> Projects { get; private set; } = [];

    /// <summary>
    /// The list of resources for this Workspace.
    /// (Lazy Loaded)
    /// </summary>
    public virtual List<Resource> Resources { get; private set; } = [];

    /// <summary>
    /// The list of contacts for this Workspace.
    /// (Lazy Loaded)
    /// </summary>
    public virtual List<User> Contacts { get; private set; } = [];

    #endregion

    /// <summary>
    /// Private constructor for the <see cref="Workspace"/> class.
    /// </summary>
    private Workspace()
    {
        Uid = Guid.NewGuid();
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="Workspace"/> class.
    /// </summary>
    /// <returns></returns>
    public static Workspace Create()
    {
        // ! No validation needed here.
        // The workspace is to be modified using the provided methods.
        return new Workspace();
    }

    /// <summary>
    /// Updates the title of the Workspace.
    /// </summary>
    /// <param name="title">The new title to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result UpdateTitle(string title)
    {
        // ? Validate the input.
        var result = WorkspaceValidator.ValidateTitle(title);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else we want to update the title.
        Title = result;

        // * Return a success.
        return Result.Success();
    }

    /// <summary>
    /// Adds a project to the list of projects.
    /// </summary>
    /// <param name="project">Project to be added.</param>
    /// <returns>A <see cref="Result"/> indicating if the title is valid or not.</returns>
    public Result AddProject(Project? project)
    {
        // ? Validate the project.
        var result = WorkspaceValidator.ValidateAddProject(project, Projects);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else we want to add the project.
        // It is safe to assume that the result is not null.
        Projects.Add(result);

        // * Return a success.
        return Result.Success();
    }

    /// <summary>
    /// Removes a project from the list of projects.
    /// </summary>
    /// <param name="project">Project to be removed.</param>
    /// <returns>A <see cref="Result"/> indicating if the title is valid or not.</returns>
    public Result RemoveProject(Project? project)
    {
        // ? Validate the project.
        var result = WorkspaceValidator.ValidateRemoveProject(project, Projects);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else we want to remove the project.
        // It is safe to assume that the result is not null.
        Projects.Remove(result);

        // * Return a success.
        return Result.Success();
    }

    /// <summary>
    /// Adds a contact to the list of contacts.
    /// </summary>
    /// <param name="contact">Contact to be added.</param>
    /// <returns></returns>
    public Result AddContact(User? contact)
    {
        // ? Validate the contact.
        var result = WorkspaceValidator.ValidateAddContact(contact, Contacts);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else we want to add the contact.
        // It is safe to assume that the result is not null.
        Contacts.Add(result);

        return Result.Success();
    }

    /// <summary>
    /// Removes a contact from the list of contacts.
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    public Result RemoveContact(User? contact)
    {
        // ? Validate the contact.
        var result = WorkspaceValidator.ValidateRemoveContact(contact, Contacts);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else we want to remove the contact.
        // It is safe to assume that the result is not null.
        Contacts.Remove(result);

        return Result.Success();
    }

    /// <summary>
    /// Removes a resource from the list of resources.
    /// </summary>
    /// <param name="resource">Resource to be added.</param>
    /// <returns></returns>
    public Result AddResource(Resource? resource)
    {
        // ? Validate the resource.
        var result = WorkspaceValidator.ValidateAddResource(resource, Resources);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else we want to add the resource.
        // It is safe to assume that the result is not null.
        Resources.Add(result);

        return Result.Success();
    }

    /// <summary>
    /// Removes a resource from the list of resources.
    /// </summary>
    /// <param name="resource">Resource to be removed.</param>
    /// <returns></returns>
    public Result RemoveResource(Resource? resource)
    {
        // ? Validate the resource.
        var result = WorkspaceValidator.ValidateRemoveResource(resource, Resources);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else we want to remove the resource.
        // It is safe to assume that the result is not null.
        Resources.Remove(result);

        return Result.Success();
    }

    /// <summary>
    /// Updates the owner of the Workspace.33
    /// </summary>
    /// <param name="owner">Guid of the Owner.</param>
    /// <param name="ownerType">Type of Owner.</param>
    /// <returns></returns>
    public Result UpdateOwner(Guid owner, OwnerType ownerType)
    {
        // ? Validate the owner.
        var result = WorkspaceValidator.ValidateOwner(owner, ownerType);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else we want to update the owner.
        Owner = owner;
        OwnerType = ownerType;

        return Result.Success();
    }
}
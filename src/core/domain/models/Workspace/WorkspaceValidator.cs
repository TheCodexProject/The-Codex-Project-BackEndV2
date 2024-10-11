using domain.exceptions.common;
using domain.exceptions.models.Workspace;
using domain.models.project;
using domain.models.resource;
using domain.models.user;
using domain.models.workspace.values;
using OperationResult;

namespace domain.models.workspace;

public static class WorkspaceValidator
{
    /// <summary>
    /// Helper method to validate the title of the Workspace.
    /// </summary>
    /// <param name="title">Title to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the title is valid or not.</returns>
    public static Result<string> ValidateTitle(string title)
    {
        // ! Verifies that title holds the format of a valid title.

        // ? Is the title null or empty?
        if (string.IsNullOrWhiteSpace(title))
        {
            // ! Return a failure.
            return Result<string>.Failure(new WorkspaceTitleEmptyException());
        }

        // ? Is the title less than 3 characters?
        if (title.Length < 3)
        {
            // ! Return a failure.
            return Result<string>.Failure(new WorkspaceTitleTooShortException());
        }

        if (title.Length > 100)
        {
            // ! Return a failure.
            return Result<string>.Failure(new WorkspaceTitleTooLongException());
        }

        // * Return a success.
        return Result<string>.Success(title);
    }

    /// <summary>
    /// Helper method to validate adding a project to the Workspace.
    /// </summary>
    /// <param name="project">Project to validate.</param>
    /// <param name="projects">List of projects to validate against.</param>
    /// <returns>A <see cref="Result"/> indicating if the title is valid or not.</returns>
    public static Result<Project> ValidateAddProject(Project? project, List<Project> projects)
    {
        // ? Is the project null or empty?
        if (project == null)
        {
            // ! Return a failure.
            return Result<Project>.Failure(new NotFoundException("The provided project is invalid. Cannot be null."));
        }

        // ? Is the project's Uid null or empty?
        if (project.Uid == Guid.Empty)
        {
            // ! Return a failure.
            return Result<Project>.Failure(new NotFoundException("The provided project is invalid. Uid cannot be empty."));
        }

        // ? Is the project already in the list?
        return projects.Contains(project) ?
            // ! Return a failure.
            Result<Project>.Failure(new AlreadyExistsException("The provided project already exists in the list."))
            : // * Return a success.
            Result<Project>.Success(project);
    }

    /// <summary>
    /// Helper method to validate removing a project from the Workspace.
    /// </summary>
    /// <param name="project">Project to validate.</param>
    /// <param name="projects">List of projects to validate against.</param>
    /// <returns>A <see cref="Result"/> indicating if the title is valid or not.</returns>
    public static Result<Project> ValidateRemoveProject(Project? project, List<Project> projects)
    {
        // ? Is the project null or empty?
        if (project == null)
        {
            // ! Return a failure.
            return Result<Project>.Failure(new NotFoundException("The provided project is invalid. Cannot be null."));
        }

        // ? Is the project null or empty?
        if (project.Uid == Guid.Empty)
        {
            // ! Return a failure.
            return Result<Project>.Failure(new NotFoundException("The provided project is invalid. Uid cannot be empty."));
        }

        // ? Is the project already in the list?
        return projects.Contains(project) ?
            // * Return a success.
            Result<Project>.Success(project)
            : // ! Return a failure.
            Result<Project>.Failure(new NotFoundException("The provided project does not exist in the list."));
    }

    /// <summary>
    /// Helper method to validate adding a contact to the Workspace.
    /// </summary>
    /// <param name="contact">Contact to validate.</param>
    /// <param name="contacts">List of contacts to validate against.</param>
    /// <returns></returns>
    public static Result<User> ValidateAddContact(User? contact, List<User> contacts)
    {
        // ? Is the contact null or empty?
        if (contact == null)
        {
            return Result<User>.Failure(new NotFoundException("The provided contact is invalid. Cannot be null."));
        }

        // ? Is the contact's Uid null or empty?
        if (contact.Uid == Guid.Empty)
        {
            return Result<User>.Failure(new NotFoundException("The provided contact is invalid. Guid cannot be empty."));
        }

        // ? Is the contact already in the list?
        return contacts.Contains(contact) ?
            Result<User>.Failure(new AlreadyExistsException("The provided contact already exists in the list."))
            : Result<User>.Success(contact);
    }

    /// <summary>
    /// Helper method to validate removing a contact from the Workspace.
    /// </summary>
    /// <param name="contact">Contact to validate.</param>
    /// <param name="contacts">List of contacts to validate against.</param>
    /// <returns></returns>
    public static Result<User> ValidateRemoveContact(User? contact, List<User> contacts)
    {
        // ? Is the contact null or empty?
        if (contact == null)
        {
            return Result<User>.Failure(new NotFoundException("The provided contact is invalid. Cannot be null."));
        }

        // ? Is the contact's Uid null or empty?
        if (contact.Uid == Guid.Empty)
        {
            return Result<User>.Failure(new NotFoundException("The provided contact is invalid. Uid cannot be empty."));
        }

        // ? Is the contact already in the list?
        return contacts.Contains(contact) ?
            Result<User>.Success(contact)
            : Result<User>.Failure(new NotFoundException("The provided contact does not exist in the list."));
    }

    /// <summary>
    /// Helper method to validate adding a resource to the Workspace.
    /// </summary>
    /// <param name="resource">Resource to validate.</param>
    /// <param name="resources">List of resources to validate against.</param>
    /// <returns></returns>
    public static Result<Resource> ValidateAddResource(Resource? resource, List<Resource> resources)
    {
        // ? Is the resource null or empty?
        if (resource == null)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. Cannot be null."));
        }

        // ? Is the resource's Uid null or empty?
        if (resource.Uid == Guid.Empty)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. Uid cannot be empty."));
        }

        // ? Is the resource already in the list?
        return resources.Contains(resource) ?
            Result<Resource>.Failure(new AlreadyExistsException("The provided resource already exists in the list."))
            : Result<Resource>.Success(resource);
    }

    /// <summary>
    /// Helper method to validate removing a resource from the Workspace.
    /// </summary>
    /// <param name="resource">Resource to validate</param>
    /// <param name="resources">List of resources to validate against.</param>
    /// <returns></returns>
    public static Result<Resource> ValidateRemoveResource(Resource? resource, List<Resource> resources)
    {
        // ? Is the resource null or empty?
        if (resource == null)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. Cannot be null."));
        }

        // ? Is the resource's Uid null or empty?
        if (resource.Uid == Guid.Empty)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. Uid cannot be empty."));
        }

        // ? Is the resource already in the list?
        return resources.Contains(resource) ?
            Result<Resource>.Success(resource)
            : Result<Resource>.Failure(new NotFoundException("The provided resource does not exist in the list."));
    }

    /// <summary>
    /// Helper method to validate the owner of the Workspace.
    /// </summary>
    /// <param name="owner">Guid to validate.</param>
    /// <param name="ownerType">Type to validate.</param>
    /// <returns></returns>
    public static Result ValidateOwner(Guid owner, OwnerType ownerType)
    {
        if (owner == Guid.Empty)
        {
            return Result.Failure(new NotFoundException("The provided owner is invalid. Guid cannot be empty."));
        }

        // ? Is the owner type valid? (In enum)
        if (!Enum.IsDefined(typeof(OwnerType), ownerType))
        {
            return Result.Failure(new NotFoundException("The provided owner type is invalid. Must be either User or Organization."));
        }

        return Result.Success();
    }
}
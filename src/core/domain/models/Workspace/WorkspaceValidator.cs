using domain.exceptions.common;
using domain.exceptions.models.Workspace;
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
    public static Result<Guid> ValidateAddProject(Guid project, List<Guid> projects)
    {
        // ? Is the project null or empty?
        if (project == Guid.Empty)
        {
            // ! Return a failure.
            return Result<Guid>.Failure(new NotFoundException("The provided project is invalid. Guid cannot be empty."));
        }

        // ? Is the project already in the list?
        return projects.Contains(project) ?
            // ! Return a failure.
            Result<Guid>.Failure(new AlreadyExistsException("The provided project already exists in the list."))
            : // * Return a success.
            Result<Guid>.Success(project);
    }

    /// <summary>
    /// Helper method to validate removing a project from the Workspace.
    /// </summary>
    /// <param name="project">Project to validate.</param>
    /// <param name="projects">List of projects to validate against.</param>
    /// <returns>A <see cref="Result"/> indicating if the title is valid or not.</returns>
    public static Result<Guid> ValidateRemoveProject(Guid project, List<Guid> projects)
    {
        // ? Is the project null or empty?
        if (project == Guid.Empty)
        {
            // ! Return a failure.
            return Result<Guid>.Failure(new NotFoundException("The provided project is invalid. Guid cannot be empty."));
        }

        // ? Is the project already in the list?
        return projects.Contains(project) ?
            // * Return a success.
            Result<Guid>.Success(project)
            : // ! Return a failure.
            Result<Guid>.Failure(new NotFoundException("The provided project does not exist in the list."));
    }

    /// <summary>
    /// Helper method to validate adding a contact to the Workspace.
    /// </summary>
    /// <param name="contact">Contact to validate.</param>
    /// <param name="contacts">List of contacts to validate against.</param>
    /// <returns></returns>
    public static Result<Guid> ValidateAddContact(Guid contact, List<Guid> contacts)
    {
        if (contact == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided contact is invalid. Guid cannot be empty."));
        }

        return contacts.Contains(contact) ?
            Result<Guid>.Failure(new AlreadyExistsException("The provided contact already exists in the list."))
            : Result<Guid>.Success(contact);
    }

    /// <summary>
    /// Helper method to validate removing a contact from the Workspace.
    /// </summary>
    /// <param name="contact">Contact to validate.</param>
    /// <param name="contacts">List of contacts to validate against.</param>
    /// <returns></returns>
    public static Result<Guid> ValidateRemoveContact(Guid contact, List<Guid> contacts)
    {
        if (contact == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided contact is invalid. Guid cannot be empty."));
        }

        return contacts.Contains(contact) ?
            Result<Guid>.Success(contact)
            : Result<Guid>.Failure(new NotFoundException("The provided contact does not exist in the list."));
    }

    /// <summary>
    /// Helper method to validate adding a resource to the Workspace.
    /// </summary>
    /// <param name="resource">Resource to validate.</param>
    /// <param name="resources">List of resources to validate against.</param>
    /// <returns></returns>
    public static Result<Guid> ValidateAddResource(Guid resource, List<Guid> resources)
    {
        if (resource == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided resource is invalid. Guid cannot be empty."));
        }

        return resources.Contains(resource) ?
            Result<Guid>.Failure(new AlreadyExistsException("The provided resource already exists in the list."))
            : Result<Guid>.Success(resource);
    }

    /// <summary>
    /// Helper method to validate removing a resource from the Workspace.
    /// </summary>
    /// <param name="resource">Resource to validate</param>
    /// <param name="resources">List of resources to validate against.</param>
    /// <returns></returns>
    public static Result<Guid> ValidateRemoveResource(Guid resource, List<Guid> resources)
    {
        if (resource == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided resource is invalid. Guid cannot be empty."));
        }

        return resources.Contains(resource) ?
            Result<Guid>.Success(resource)
            : Result<Guid>.Failure(new NotFoundException("The provided resource does not exist in the list."));
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
            return Result.Failure(new NotFoundException("The provided owner type is invalid. Must be either User or Organisation."));
        }

        return Result.Success();
    }
}
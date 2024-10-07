using domain.exceptions.common;
using domain.exceptions.models.organisation;
using domain.models.user;
using domain.models.resource;
using OperationResult;

namespace domain.models.Organisation;

public class OrganisationValidator
{
    public static Result<string> ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result<string>.Failure(new OrganisationNameEmptyException());
        }

        return name.Length switch
        {
            < 2 => Result<string>.Failure(new OrganisationNameTooShortException()),
            > 100 => Result<string>.Failure(new OrganisationNameTooLongException()),
            _ => Result<string>.Success(name)
        };
    }

    public static Result<Guid> ValidateAddOwner(Guid owner, List<Guid> owners)
    {
        if (owner == null)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided owner is invalid. owner cannot be null."));
        }

        if (owner == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided owner is invalid. Guid cannot be empty."));
        }

        return owners.Contains(owner) ?
            Result<Guid>.Failure(new AlreadyExistsException("The provided owner already exists in the list."))
            : Result<Guid>.Success(owner);
    }

    public static Result<Guid> ValidateRemoveOwner(Guid owner, List<Guid> owners)
    {
        if (owner == null)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided owner is invalid. owner cannot be null."));
        }

        if (owner == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided owner is invalid. Guid cannot be empty."));
        }

        return owners.Contains(owner) ?
            Result<Guid>.Success(owner)
            : Result<Guid>.Failure(new NotFoundException("The provided owner does not exist in the list."));
    }

    public static Result<Guid> ValidateAddResource(Guid resource, List<Guid> resources)
    {
        if (resource == null)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided resource is invalid. resource cannot be null."));
        }

        if (resource == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided resource is invalid. Guid cannot be empty."));
        }

        return resources.Contains(resource) ?
            Result<Guid>.Failure(new AlreadyExistsException("The provided resource already exists in the list."))
            : Result<Guid>.Success(resource);
    }

    public static Result<Guid> ValidateRemoveResource(Guid resource, List<Guid> resources)
    {
        if (resource == null)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided resource is invalid. resource cannot be null."));
        }

        if (resource == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided resource is invalid. Guid cannot be empty."));
        }

        return resources.Contains(resource) ?
            Result<Guid>.Success(resource)
            : Result<Guid>.Failure(new NotFoundException("The provided resource does not exist in the list."));
    }
}
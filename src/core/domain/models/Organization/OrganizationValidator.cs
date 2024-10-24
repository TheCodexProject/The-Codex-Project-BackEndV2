using domain.exceptions.common;
using domain.exceptions.models.Organization;
using domain.exceptions.models.organization.organizationname;
using domain.models.user;
using domain.models.resource;
using OperationResult;

namespace domain.models.organization;

public class OrganizationValidator
{
    public static Result<string> ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result<string>.Failure(new OrganizationNameEmptyException());
        }

        return name.Length switch
        {
            < 2 => Result<string>.Failure(new OrganizationNameTooShortException()),
            > 100 => Result<string>.Failure(new OrganizationNameTooLongException()),
            _ => Result<string>.Success(name)
        };
    }

    public static Result<User> ValidateAddOwner(User? owner, List<User> owners)
    {
        // ? Is the owner null or empty?
        if (owner == null)
        {
            return Result<User>.Failure(new NotFoundException("The provided owner is invalid. owner cannot be null."));
        }

        // ? Is the owner's Guid null or empty?
        if (owner.Uid == Guid.Empty)
        {
            return Result<User>.Failure(new NotFoundException("The provided owner is invalid. Guid cannot be empty."));
        }

        // ? Does the owner already exist in the list?
        return owners.Contains(owner) ?
            Result<User>.Failure(new AlreadyExistsException("The provided owner already exists in the list."))
            : Result<User>.Success(owner);
    }

    public static Result<User> ValidateRemoveOwner(User? owner, List<User> owners)
    {
        // ? Is the owner null or empty?
        if (owner == null)
        {
            return Result<User>.Failure(new NotFoundException("The provided owner is invalid. owner cannot be null."));
        }

        // ? Is the owner's Guid null or empty?
        if (owner.Uid == Guid.Empty)
        {
            return Result<User>.Failure(new NotFoundException("The provided owner is invalid. Guid cannot be empty."));
        }

        // ? If there is only one owner, it cannot be removed.
        if (owners.Count == 1)
        {
            return Result<User>.Failure(new OrganizationNeedsAtLeastOneOwnerException());
        }

        // ? Does the owner exist in the list?
        return owners.Contains(owner) ?
            Result<User>.Success(owner)
            : Result<User>.Failure(new NotFoundException("The provided owner does not exist in the list."));
    }

    public static Result<Resource> ValidateAddResource(Resource? resource, List<Resource> resources)
    {
        // ? Is the resource null or empty?
        if (resource == null)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. resource cannot be null."));
        }

        // ? Is the resource's Guid null or empty?
        if (resource.Uid == Guid.Empty)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. Guid cannot be empty."));
        }

        // ? Does the resource already exist in the list?
        return resources.Contains(resource) ?
            Result<Resource>.Failure(new AlreadyExistsException("The provided resource already exists in the list."))
            : Result<Resource>.Success(resource);
    }

    public static Result<Resource> ValidateRemoveResource(Resource? resource, List<Resource> resources)
    {
        // ? Is the resource null or empty?
        if (resource == null)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. resource cannot be null."));
        }

        // ? Is the resource's Guid null or empty?
        if (resource.Uid == Guid.Empty)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. Guid cannot be empty."));
        }

        // ? Does the resource exist in the list?
        return resources.Contains(resource) ?
            Result<Resource>.Success(resource)
            : Result<Resource>.Failure(new NotFoundException("The provided resource does not exist in the list."));
    }
}
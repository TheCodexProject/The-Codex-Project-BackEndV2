using domain.exceptions.common;
using domain.exceptions.models.WorkItem.Description;
using domain.exceptions.models.WorkItem.Title;
using domain.models.user;
using domain.models.values;
using OperationResult;

namespace domain.models.workitem;

public static class WorkItemValidator
{
    public static Result<string> ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result<string>.Failure(new WorkItemTitleEmptyException());
        }

        return title.Length switch
        {
            < 3 => Result<string>.Failure(new WorkItemTitleTooShortException()),
            > 75 => Result<string>.Failure(new WorkItemTitleTooLongException()),
            _ => Result<string>.Success(title)
        };
    }

    public static Result<string> ValidateDescription(string description)
    {
        // Description is optional
        if (string.IsNullOrWhiteSpace(description))
        {
            return Result<string>.Success(description);
        }

        return description.Length switch
        {
          > 500 => Result<string>.Failure(new WorkItemDescriptionTooLongException()),
           _ => Result<string>.Success(description)
        };
    }

    public static Result<Status> ValidateStatus(Status status)
    {
        return status switch
        {
            Status.None => Result<Status>.Success(status),
            Status.Open => Result<Status>.Success(status),
            Status.InProgress => Result<Status>.Success(status),
            Status.ReadyForReview => Result<Status>.Success(status),
            Status.Done => Result<Status>.Success(status),
            Status.Closed => Result<Status>.Success(status),
            _ => Result<Status>.Failure(new NotFoundException("Status not found"))
        };
    }

    public static Result<Priority> ValidatePriority(Priority priority)
    {
        return priority switch
        {
            Priority.None => Result<Priority>.Success(priority),
            Priority.Low => Result<Priority>.Success(priority),
            Priority.Medium => Result<Priority>.Success(priority),
            Priority.High => Result<Priority>.Success(priority),
            Priority.Critical => Result<Priority>.Success(priority),
            _ => Result<Priority>.Failure(new NotFoundException("Priority not found"))
        };
    }

    public static Result<ItemType> ValidateType(ItemType type)
    {
        return type switch
        {
            ItemType.None => Result<ItemType>.Success(type),
            ItemType.Bug => Result<ItemType>.Success(type),
            ItemType.Story => Result<ItemType>.Success(type),
            ItemType.Task => Result<ItemType>.Success(type),
            ItemType.Epic => Result<ItemType>.Success(type),
            _ => Result<ItemType>.Failure(new NotFoundException("Type not found"))
        };
    }

    public static Result<User> ValidateAssignee(User assignee)
    {
        return assignee switch
        {
            null => Result<User>.Failure(new NotFoundException("Assignee not found")),
            _ => Result<User>.Success(assignee)
        };
    }

    public static Result<Guid> ValidateAddSubItem(WorkItem? subItem, List<Guid> subItems)
    {
        if (subItem == null)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided subItem is invalid. subItem cannot be null."));
        }

        if (subItem.Uid == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided subItem is invalid. Guid cannot be empty."));
        }

        return subItems.Contains(subItem.Uid) ?
            Result<Guid>.Failure(new AlreadyExistsException("The provided subItem already exists in the list."))
            : Result<Guid>.Success(subItem.Uid);
    }

    public static Result<Guid> ValidateRemoveSubItem(WorkItem? subItem, List<Guid> subItems)
    {
        if(subItem == null)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided subItem is invalid. subItem cannot be null."));
        }

        if (subItem.Uid == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided subItem is invalid. Guid cannot be empty."));
        }

        return subItems.Contains(subItem.Uid) ?
            Result<Guid>.Success(subItem.Uid)
            : Result<Guid>.Failure(new NotFoundException("The provided subItem does not exist in the list."));
    }

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

    public static Result<Guid> ValidateAddDependency(Guid dependency, List<Guid> dependencies)
    {
        if (dependency == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided dependency is invalid. Guid cannot be empty."));
        }

        return dependencies.Contains(dependency) ?
            Result<Guid>.Failure(new AlreadyExistsException("The provided dependency already exists in the list."))
            : Result<Guid>.Success(dependency);
    }

    public static Result<Guid> ValidateRemoveDependency(Guid dependency, List<Guid> dependencies)
    {
        if (dependency == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided dependency is invalid. Guid cannot be empty."));
        }

        return dependencies.Contains(dependency) ?
            Result<Guid>.Success(dependency)
            : Result<Guid>.Failure(new NotFoundException("The provided dependency does not exist in the list."));
    }


}
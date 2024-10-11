using domain.exceptions.common;
using domain.exceptions.models.workitem.description;
using domain.exceptions.models.workitem.title;
using domain.models.resource;
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

    public static Result<WorkItem> ValidateAddSubItem(WorkItem? subItem, List<WorkItem> subItems)
    {
        // ? Is subitem null or empty?
        if (subItem == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided subItem is invalid. subItem cannot be null."));
        }

        // ? Is subitem's Uid empty or null?
        if (subItem.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided subItem is invalid. Uid cannot be empty."));
        }

        // ? Does the list already contain the subitem?
        return subItems.Contains(subItem) ?
            Result<WorkItem>.Failure(new AlreadyExistsException("The provided subItem already exists in the list."))
            : Result<WorkItem>.Success(subItem);
    }

    public static Result<WorkItem> ValidateRemoveSubItem(WorkItem? subItem, List<WorkItem> subItems)
    {
        // ? Is subitem null or empty?
        if(subItem == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided subItem is invalid. subItem cannot be null."));
        }

        // ? Is subitem's Uid empty or null?
        if (subItem.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided subItem is invalid. Uid cannot be empty."));
        }

        // ? Does the list already contain the subitem?
        return subItems.Contains(subItem) ?
            Result<WorkItem>.Success(subItem)
            : Result<WorkItem>.Failure(new NotFoundException("The provided subItem does not exist in the list."));
    }

    public static Result<Resource> ValidateAddResource(Resource? resource, List<Resource> resources)
    {
        // ? Is resource null or empty?
        if (resource == null)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. Resource cannot be null."));
        }

        // ? Is resource's Uid empty or null?
        if (resource.Uid == Guid.Empty)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. Uid cannot be empty."));
        }

        return resources.Contains(resource) ?
            Result<Resource>.Failure(new AlreadyExistsException("The provided resource already exists in the list."))
            : Result<Resource>.Success(resource);
    }

    public static Result<Resource> ValidateRemoveResource(Resource? resource, List<Resource> resources)
    {
        // ? Is resource null or empty?
        if (resource == null)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. Resource cannot be null."));
        }

        // ? Is resource's Uid empty or null?
        if (resource.Uid == Guid.Empty)
        {
            return Result<Resource>.Failure(new NotFoundException("The provided resource is invalid. Uid cannot be empty."));
        }

        // ? Does the list already contain the resource?
        return resources.Contains(resource) ?
            Result<Resource>.Success(resource)
            : Result<Resource>.Failure(new NotFoundException("The provided resource does not exist in the list."));
    }

    public static Result<WorkItem> ValidateAddDependency(WorkItem? dependency, List<WorkItem> dependencies)
    {
        // ? Is dependency null or empty?
        if (dependency == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided dependency is invalid. Dependency cannot be null."));
        }

        // ? Is dependency's Uid empty or null?
        if (dependency.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided dependency is invalid. Uid cannot be empty."));
        }

        // ? Does the list already contain the dependency?
        return dependencies.Contains(dependency) ?
            Result<WorkItem>.Failure(new AlreadyExistsException("The provided dependency already exists in the list."))
            : Result<WorkItem>.Success(dependency);
    }

    public static Result<WorkItem> ValidateRemoveDependency(WorkItem? dependency, List<WorkItem> dependencies)
    {
        // ? Is dependency null or empty?
        if (dependency == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided dependency is invalid. Dependency cannot be null."));
        }

        // ? Is dependency's Uid empty or null?
        if (dependency.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided dependency is invalid. Guid cannot be empty."));
        }

        // ? Does the list already contain the dependency?
        return dependencies.Contains(dependency) ?
            Result<WorkItem>.Success(dependency)
            : Result<WorkItem>.Failure(new NotFoundException("The provided dependency does not exist in the list."));
    }

}
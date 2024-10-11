using domain.exceptions.common;
using domain.exceptions.models.milestone.milestonetitle;
using domain.models.workitem;
using OperationResult;

namespace domain.models.milestone;

public class MilestoneValidator
{
    public static Result<string> ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result<string>.Failure(new MilestoneTitleEmptyException());
        }

        return title.Length switch
        {
            < 3 => Result<string>.Failure(new MilestoneTitleTooShortException()),
            > 75 => Result<string>.Failure(new MilestoneTitleTooLongException()),
            _ => Result<string>.Success(title)
        };
    }

    public static Result<WorkItem> ValidateAddWorkItem(WorkItem? subItem, List<WorkItem> subItems)
    {
        if (subItem == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided subItem is invalid. subItem cannot be null."));
        }

        if (subItem.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided subItem is invalid. Guid cannot be empty."));
        }

        return subItems.Contains(subItem) ?
            Result<WorkItem>.Failure(new AlreadyExistsException("The provided subItem already exists in the list."))
            : Result<WorkItem>.Success(subItem);
    }

    public static Result<WorkItem> ValidateRemoveWorkItem(WorkItem? subItem, List<WorkItem> subItems)
    {
        if (subItem == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided subItem is invalid. subItem cannot be null."));
        }

        if (subItem.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided subItem is invalid. Guid cannot be empty."));
        }

        return subItems.Contains(subItem) ?
            Result<WorkItem>.Success(subItem)
            : Result<WorkItem>.Failure(new NotFoundException("The provided subItem does not exist in the list."));
    }
}

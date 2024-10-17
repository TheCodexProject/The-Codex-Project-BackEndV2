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

    public static Result<WorkItem> ValidateAddWorkItem(WorkItem? workItem, List<WorkItem> workItems)
    {
        if (workItem == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided workItem is invalid. workItem cannot be null."));
        }

        if (workItem.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided workItem is invalid. Guid cannot be empty."));
        }

        return workItems.Contains(workItem) ?
            Result<WorkItem>.Failure(new AlreadyExistsException("The provided workItem already exists in the list."))
            : Result<WorkItem>.Success(workItem);
    }

    public static Result<WorkItem> ValidateRemoveWorkItem(WorkItem? workItem, List<WorkItem> workItems)
    {
        if (workItem == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided workItem is invalid. workItem cannot be null."));
        }

        if (workItem.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided workItem is invalid. Guid cannot be empty."));
        }

        return workItems.Contains(workItem) ?
            Result<WorkItem>.Success(workItem)
            : Result<WorkItem>.Failure(new NotFoundException("The provided workItem does not exist in the list."));
    }
}

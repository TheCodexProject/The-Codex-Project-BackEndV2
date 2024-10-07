using domain.exceptions.common;
using domain.exceptions.milestone.milestoneContent;
using domain.exceptions.milestone.milestoneTitle;
using domain.models.workitem;
using OperationResult;

namespace domain.models.Milestone;

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

    public static Result<string> ValidateContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return Result<string>.Failure(new MilestoneContentEmptyException());
        }
        else
        {
            return Result<string>.Success(content);
        }
    }

    public static Result<Guid> ValidateAddWorkItem(WorkItem? workItem, List<Guid> subItems)
    {
        if (workItem == null)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided subItem is invalid. subItem cannot be null."));
        }

        if (workItem.Uid == Guid.Empty)
        {
            return Result<Guid>.Failure(new NotFoundException("The provided subItem is invalid. Guid cannot be empty."));
        }

        return subItems.Contains(workItem.Uid) ?
            Result<Guid>.Failure(new AlreadyExistsException("The provided subItem already exists in the list."))
            : Result<Guid>.Success(workItem.Uid);
    }

    public static Result<Guid> ValidateRemoveWorkItem(WorkItem? subItem, List<Guid> subItems)
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
            Result<Guid>.Success(subItem.Uid)
            : Result<Guid>.Failure(new NotFoundException("The provided subItem does not exist in the list."));
    }
}

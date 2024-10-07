using domain.exceptions.common;
using domain.exceptions.models.project.Description;
using domain.exceptions.models.project.Status;
using domain.exceptions.models.project.TimeRange;
using domain.exceptions.models.project.Title;
using domain.models.board;
using domain.models.iteration;
using domain.models.milestone;
using domain.models.values;
using domain.models.workitem;
using OperationResult;

namespace domain.models.project;

public static class ProjectValidator
{
    public static Result<string> ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result<string>.Failure(new ProjectTitleEmptyException());
        }

        if(title.Length < 3)
        {
            return Result<string>.Failure(new ProjectTitleTooShortException());
        }

        if (title.Length > 75)
        {
            return Result<string>.Failure(new ProjectTitleTooLongException());
        }

        return Result<string>.Success(title);
    }

    public static Result<string> ValidateDescription(string description)
    {
        if (description.Length > 500)
        {
            return Result<string>.Failure(new ProjectDescriptionTooLongException());
        }

        return Result<string>.Success(description);
    }

    public static Result<Status> ValidateStatus(Status status)
    {
        return status == Status.None ? Result<Status>.Failure(new ProjectStatusEmptyException()) : Result<Status>.Success(status);
    }

    public static Result<(DateTime start, DateTime end)> ValidateTimeRange(DateTime start, DateTime end)
    {
        if (start == DateTime.MinValue || end == DateTime.MinValue)
        {
            return Result<(DateTime start, DateTime end)>.Failure(new ProjectTimeRangeInvalidException());
        }

        if (start < DateTime.Today)
        {
            return Result<(DateTime start, DateTime end)>.Failure(new ProjectTimeRangeStartInThePastException());
        }

        // Is start date before end date?
        if (end < start)
        {
            return Result<(DateTime start, DateTime end)>.Failure(new ProjectTimeRangeEndBeforeStartException());
        }

        // Is start date after end date?
        if (start > end)
        {
            return Result<(DateTime start, DateTime end)>.Failure(new ProjectTimeRangeStartAfterEndException());
        }

        // Is start date the same as end date?
        if (start == end)
        {
            return Result<(DateTime start, DateTime end)>.Failure(new ProjectTimeRangeStartEqualsEndException());
        }

        return Result<(DateTime start, DateTime end)>.Success((start, end));
    }

    public static Result<WorkItem> ValidateAddWorkItem(WorkItem? item, List<WorkItem> items)
    {
        if (item == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided item is invalid. Item cannot be null."));
        }

        if (item.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided item is invalid. Item cannot have an empty Uid."));
        }

        // Check if the item already exists in the list.
        if (items.Contains(item))
        {
            return Result<WorkItem>.Failure(new AlreadyExistsException("The provided item already exists in the list."));
        }


        return  Result<WorkItem>.Success(item);
    }

    public static Result<WorkItem> ValidateRemoveWorkItem(WorkItem? item, List<WorkItem> items)
    {
        if (item == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided item is invalid. Item cannot be null."));
        }

        if (item.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided item is invalid. Item cannot have an empty Uid."));
        }

        return items.Any(i => i.Uid == item.Uid) ?
            Result<WorkItem>.Success(item)
            : Result<WorkItem>.Failure(new NotFoundException("The provided item does not exist in the list."));
    }

    public static Result<Milestone> ValidateAddMilestone(Milestone? milestone, List<Milestone> milestones)
    {
        if (milestone == null)
        {
            return Result<Milestone>.Failure(new NotFoundException("The provided milestone is invalid. Milestone cannot be null."));
        }

        if (milestone.Uid == Guid.Empty)
        {
            return Result<Milestone>.Failure(new NotFoundException("The provided milestone is invalid. Milestone cannot have an empty Uid."));
        }

        if (milestones.Contains(milestone))
        {
            return Result<Milestone>.Failure(new AlreadyExistsException("The provided milestone already exists in the list."));
        }

        return  Result<Milestone>.Success(milestone);
    }

    public static Result<Milestone> ValidateRemoveMilestone(Milestone? milestone, List<Milestone> milestones)
    {
        if (milestone == null)
        {
            return Result<Milestone>.Failure(new NotFoundException("The provided milestone is invalid. Milestone cannot be null."));
        }

        if (milestone.Uid == Guid.Empty)
        {
            return Result<Milestone>.Failure(new NotFoundException("The provided milestone is invalid. Milestone cannot have an empty Uid."));
        }

        return milestones.Any(m => m.Uid == milestone.Uid) ?
            Result<Milestone>.Success(milestone)
            : Result<Milestone>.Failure(new NotFoundException("The provided milestone does not exist in the list."));
    }

    public static Result<Iteration> ValidateAddIteration(Iteration? iteration, List<Iteration> iterations)
    {
        if (iteration == null)
        {
            return Result<Iteration>.Failure(new NotFoundException("The provided iteration is invalid. Iteration cannot be null."));
        }

        if (iteration.Uid == Guid.Empty)
        {
            return Result<Iteration>.Failure(new NotFoundException("The provided iteration is invalid. Iteration cannot have an empty Uid."));
        }

        if (iterations.Contains(iteration))
        {
            return Result<Iteration>.Failure(new AlreadyExistsException("The provided iteration already exists in the list."));
        }

        return Result<Iteration>.Success(iteration);
    }

    public static Result<Iteration> ValidateRemoveIteration(Iteration? iteration, List<Iteration> iterations)
    {
        if (iteration == null)
        {
            return Result<Iteration>.Failure(new NotFoundException("The provided iteration is invalid. Iteration cannot be null."));
        }

        if (iteration.Uid == Guid.Empty)
        {
            return Result<Iteration>.Failure(new NotFoundException("The provided iteration is invalid. Iteration cannot have an empty Uid."));
        }

        return iterations.Any(i => i.Uid == iteration.Uid) ?
            Result<Iteration>.Success(iteration)
            : Result<Iteration>.Failure(new NotFoundException("The provided iteration does not exist in the list."));
    }

    public static Result<Board> ValidateAddBoard(Board? board, List<Board> boards)
    {
        if (board == null)
        {
            return Result<Board>.Failure(new NotFoundException("The provided board is invalid. Board cannot be null."));
        }

        if (board.Uid == Guid.Empty)
        {
            return Result<Board>.Failure(new NotFoundException("The provided board is invalid. Board cannot have an empty Uid."));
        }

        if(boards.Contains(board))
        {
            return Result<Board>.Failure(new AlreadyExistsException("The provided board already exists in the list."));
        }


        return Result<Board>.Success(board);
    }

    public static Result<Board> ValidateRemoveBoard(Board? board, List<Board> boards)
    {
        if (board == null)
        {
            return Result<Board>.Failure(new NotFoundException("The provided board is invalid. Board cannot be null."));
        }

        if (board.Uid == Guid.Empty)
        {
            return Result<Board>.Failure(new NotFoundException("The provided board is invalid. Board cannot have an empty Uid."));
        }

        return boards.Any(b => b.Uid == board.Uid) ?
            Result<Board>.Success(board)
            : Result<Board>.Failure(new NotFoundException("The provided board does not exist in the list."));
    }
}
using domain.exceptions.common;
using domain.exceptions.models.iteration.iterationTitle;
using domain.models.workitem;
using OperationResult;

namespace domain.models.iteration;

public static class IterationValidator
{
    /// <summary>
    /// Helper method to validate the title of the Iteration.
    /// </summary>
    /// <param name="title">Title to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the title is valid or not.</returns>
    public static Result<string> ValidateTitle(string title)
    {
        // ? Is the title null or empty?
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result<string>.Failure(new IterationTitleEmptyException());
        }

        // ? Is the title less than 3 characters?
        if (title.Length < 3)
        {
            return Result<string>.Failure(new IterationTitleTooShortException());
        }

        // ? Is the title longer than 75 characters?
        if (title.Length > 75)
        {
            return Result<string>.Failure(new IterationTitleTooLongException());
        }

        // * Return a success.
        return Result<string>.Success(title);
    }

    /// <summary>
    /// Helper method to validate adding a work item to the Iteration.
    /// </summary>
    /// <param name="workItem">Work item to validate.</param>
    /// <param name="workItems">List of work items to validate against.</param>
    /// <returns>A <see cref="Result"/> indicating if the work item is valid or not.</returns>
    public static Result<WorkItem> ValidateAddWorkItem(WorkItem? workItem, List<WorkItem> workItems)
    {
        // ? Is the work item null or empty?
        if (workItem == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided work item is invalid. Guid cannot be empty."));
        }

        // ? Is the work item null or empty?
        if (workItem.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided work item is invalid. Guid cannot be empty."));
        }

        // ? Is the work item already in the list?
        return workItems.Contains(workItem) ?
            Result<WorkItem>.Failure(new AlreadyExistsException("The provided work item already exists in the list."))
            : Result<WorkItem>.Success(workItem);
    }

    /// <summary>
    /// Helper method to validate removing a work item from the Iteration.
    /// </summary>
    /// <param name="workItem">Work item to validate.</param>
    /// <param name="workItems">List of work items to validate against.</param>
    /// <returns>A <see cref="Result"/> indicating if the work item is valid or not.</returns>
    public static Result<WorkItem> ValidateRemoveWorkItem(WorkItem? workItem, List<WorkItem> workItems)
    {
        // ? Is the work item null or empty?
        if (workItem == null)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided work item is invalid. Guid cannot be empty."));
        }

        // ? Is the work item null or empty?
        if (workItem.Uid == Guid.Empty)
        {
            return Result<WorkItem>.Failure(new NotFoundException("The provided work item is invalid. Guid cannot be empty."));
        }

        // ? Does the work item exist in the list?
        return workItems.Contains(workItem) ?
            Result<WorkItem>.Success(workItem)
            : Result<WorkItem>.Failure(new NotFoundException("The provided work item does not exist in the list."));
    }
}
namespace domain.exceptions.models.workitem.title;

/// <summary>
/// An exception for when a WorkItem is created with a title that is too long.
/// </summary>
public class WorkItemTitleTooLongException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public WorkItemTitleTooLongException() : base("Title is too long, it cannot be more than 75 characters.") { }
}
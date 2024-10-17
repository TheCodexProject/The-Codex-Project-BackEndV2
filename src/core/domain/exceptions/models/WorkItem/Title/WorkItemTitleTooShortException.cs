namespace domain.exceptions.models.workitem.title;

/// <summary>
/// An exception for when a WorkItem is created with a title that is too short.
/// </summary>
public class WorkItemTitleTooShortException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public WorkItemTitleTooShortException() : base("Title is too short, it cannot be less than 3 characters.") { }
}
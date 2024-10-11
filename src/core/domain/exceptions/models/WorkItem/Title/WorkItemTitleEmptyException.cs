namespace domain.exceptions.models.workitem.title;

/// <summary>
/// An exception for when a WorkItem is created without a title.
/// </summary>
public class WorkItemTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkItemTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }
}
namespace domain.exceptions.models.workitem.description;

/// <summary>
/// An exception for when a WorkItem is created with a description that is too long.
/// </summary>
public class WorkItemDescriptionTooLongException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public WorkItemDescriptionTooLongException() : base("Description is too long, it cannot be more than 500 characters.") { }
}
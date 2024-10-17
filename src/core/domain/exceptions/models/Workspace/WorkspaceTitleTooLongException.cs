namespace domain.exceptions.models.workspace;

/// <summary>
/// An exception for when a Workspace is created with a title that is too long.
/// </summary>
public class WorkspaceTitleTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceTitleTooLongException() : base("Title cannot be more then 75 characters") { }
}

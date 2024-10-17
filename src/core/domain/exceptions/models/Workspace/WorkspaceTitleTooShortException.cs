namespace domain.exceptions.models.workspace;

/// <summary>
/// An exception for when a Workspace is created with a title that is too short.
/// </summary>
public class WorkspaceTitleTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceTitleTooShortException() : base("Title is too short, it must be more then 3 characters.") { }
}

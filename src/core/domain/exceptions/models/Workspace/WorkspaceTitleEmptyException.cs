namespace domain.exceptions.models.workspace;

/// <summary>
/// An exception for when a Workspace is created with an empty title.
/// </summary>
public class WorkspaceTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }
}
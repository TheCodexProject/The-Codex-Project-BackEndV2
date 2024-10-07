namespace domain.exceptions.models.Workspace;

/// <summary>
/// Exception for when a workspace is created with a too short title
/// </summary>
public class WorkspaceTitleTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceTitleTooShortException() : base("Title is too short, it must be more then 3 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceTitleTooShortException(string message) : base(message) { }
}

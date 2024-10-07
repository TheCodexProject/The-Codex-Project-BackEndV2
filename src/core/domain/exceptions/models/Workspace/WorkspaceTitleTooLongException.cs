namespace domain.exceptions.models.Workspace;

/// <summary>
/// Exception for when a Workspace is created with a title that are too long.
/// </summary>
public class WorkspaceTitleTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceTitleTooLongException() : base("Title cannot be more then 75 characters") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceTitleTooLongException(string message) : base(message) { }
}

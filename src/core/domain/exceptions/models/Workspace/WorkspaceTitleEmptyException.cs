namespace domain.exceptions.models.Workspace;

public class WorkspaceTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceTitleEmptyException(string message) : base(message) { }
}
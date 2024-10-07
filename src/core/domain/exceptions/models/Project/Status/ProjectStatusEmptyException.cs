namespace domain.exceptions.models.project.status;

/// <summary>
/// An exception used when the project status is empty.
/// </summary>
public class ProjectStatusEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectStatusEmptyException() : base("Status cannot be left empty.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectStatusEmptyException(string message) : base(message) { }
}
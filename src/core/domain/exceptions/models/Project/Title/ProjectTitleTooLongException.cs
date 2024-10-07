namespace domain.exceptions.models.project.title;

/// <summary>
/// An exception used when the project title is too long.
/// </summary>
public class ProjectTitleTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectTitleTooLongException() : base("Title is too long, it cannot be more than 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectTitleTooLongException(string message) : base(message) { }
}
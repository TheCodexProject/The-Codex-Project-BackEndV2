namespace domain.exceptions.models.project.Title;

/// <summary>
/// An exception used when the project title is too short.
/// </summary>
public class ProjectTitleTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectTitleTooShortException() : base("Title is too short, it cannot be less than 3 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectTitleTooShortException(string message) : base(message) { }
}
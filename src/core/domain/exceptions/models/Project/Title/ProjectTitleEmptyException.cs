namespace domain.exceptions.models.project.Title;

/// <summary>
/// An exception used when the project title is empty.
/// </summary>
[Serializable]
public class ProjectTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectTitleEmptyException(string message) : base(message) { }
}
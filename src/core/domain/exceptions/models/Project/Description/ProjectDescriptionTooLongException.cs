namespace domain.exceptions.models.project.description;

/// <summary>
/// An exception used when the project description is too long.
/// </summary>
public class ProjectDescriptionTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectDescriptionTooLongException() : base("Description is too long, it cannot be more than 500 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectDescriptionTooLongException(string message) : base(message) { }
}
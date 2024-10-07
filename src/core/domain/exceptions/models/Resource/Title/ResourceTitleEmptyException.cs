namespace domain.exceptions.models.resource.Title;

/// <summary>
/// An exception that is thrown when the title of a resource is empty.
/// </summary>
public class ResourceTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ResourceTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ResourceTitleEmptyException(string message) : base(message) { }
}
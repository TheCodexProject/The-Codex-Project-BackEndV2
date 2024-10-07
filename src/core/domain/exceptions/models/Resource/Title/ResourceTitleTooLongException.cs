namespace domain.exceptions.models.resource.Title;

/// <summary>
/// An exception that is thrown when the title of a resource is too long.
/// </summary>
public class ResourceTitleTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ResourceTitleTooLongException() : base("Title is too long, it cannot be more than 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ResourceTitleTooLongException(string message) : base(message) { }
} 
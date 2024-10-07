namespace domain.exceptions.models.resource.Title;

/// <summary>
/// An exception that is thrown when the title of a resource is too short.
/// </summary>
public class ResourceTitleTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ResourceTitleTooShortException() : base("Title is too short, it cannot be less than 3 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ResourceTitleTooShortException(string message) : base(message) { }

}
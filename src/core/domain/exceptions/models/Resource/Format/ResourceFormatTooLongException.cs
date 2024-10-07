namespace domain.exceptions.models.resource.format;

/// <summary>
/// An exception that is thrown when the format of a resource is too long.
/// </summary>
public class ResourceFormatTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ResourceFormatTooLongException() : base("Format is too long, it cannot be more than 10 characters and must include a dot ('.')") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ResourceFormatTooLongException(string message) : base(message) { }
}
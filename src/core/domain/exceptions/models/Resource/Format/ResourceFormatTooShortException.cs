namespace domain.exceptions.models.resource.Format;

/// <summary>
/// An exception that is thrown when the format of a resource is too long.
/// </summary>
public class ResourceFormatTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ResourceFormatTooShortException() : base("Format is too short, it cannot be less than 2 characters and must include a dot ('.')") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ResourceFormatTooShortException(string message) : base(message) { }
}
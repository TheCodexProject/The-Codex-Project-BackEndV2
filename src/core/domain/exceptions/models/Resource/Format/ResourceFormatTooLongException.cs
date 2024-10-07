namespace domain.exceptions.models.resource.Format;

/// <summary>
/// Exception for when a Documentation format is too long.
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
namespace domain.exceptions.models.resource.Format;

/// <summary>
/// Exception for when a Documentation format is too short.
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
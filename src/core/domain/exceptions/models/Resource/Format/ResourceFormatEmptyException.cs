namespace domain.exceptions.models.resource.format;

/// <summary>
/// An exception used when the format of a resource is empty.
/// </summary>
public class ResourceFormatEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ResourceFormatEmptyException() : base("Format cannot be empty, it must be between 2 and 10 characters, including the dot.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ResourceFormatEmptyException(string message) : base(message) { }
}
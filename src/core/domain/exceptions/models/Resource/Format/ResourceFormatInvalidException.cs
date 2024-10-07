namespace domain.exceptions.models.resource.format;

/// <summary>
/// An exception used when the format of a resource is invalid.
/// </summary>
public class ResourceFormatInvalidException : Exception
{
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ResourceFormatInvalidException(string message) : base(message) { }
}
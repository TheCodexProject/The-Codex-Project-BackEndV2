namespace domain.exceptions.models.resource.reference;

/// <summary>
/// An exception used when the reference of a resource is too long.
/// </summary>
public class ResourceReferenceTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ResourceReferenceTooLongException() : base("The Reference can not exceed 200 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ResourceReferenceTooLongException(string message) : base(message) { }
}
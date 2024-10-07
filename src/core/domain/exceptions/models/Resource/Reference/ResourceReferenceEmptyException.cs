namespace domain.exceptions.models.resource.Reference;

/// <summary>
/// An exception used when the reference of a resource is empty.
/// </summary>
public class ResourceReferenceEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ResourceReferenceEmptyException() : base("The Reference can not be empty.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ResourceReferenceEmptyException(string message) : base(message) { }
}
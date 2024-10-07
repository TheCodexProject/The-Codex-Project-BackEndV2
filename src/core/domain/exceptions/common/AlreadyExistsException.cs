namespace domain.exceptions.common;

/// <summary>
/// An exception that is thrown when a Type T already exists in a given list.
/// </summary>
public class AlreadyExistsException : Exception
{
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public AlreadyExistsException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public AlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
}
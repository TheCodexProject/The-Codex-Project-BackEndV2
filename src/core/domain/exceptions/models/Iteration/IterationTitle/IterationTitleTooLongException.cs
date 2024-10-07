
namespace domain.exceptions.models.iteration.iterationTitle;

/// <summary>
/// Exception for when a Iteration is created with a title that are too long.
/// </summary>
public class IterationTitleTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public IterationTitleTooLongException() : base("Title cannot be more then 75 characters") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public IterationTitleTooLongException(string message) : base(message) { }
}

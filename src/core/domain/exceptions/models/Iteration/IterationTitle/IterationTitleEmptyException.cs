
namespace domain.exceptions.models.iteration.iterationTitle;

/// <summary>
/// Exception for when a Iteration is created without a title.
/// </summary>
public class IterationTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public IterationTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public IterationTitleEmptyException(string message) : base(message) { }
}

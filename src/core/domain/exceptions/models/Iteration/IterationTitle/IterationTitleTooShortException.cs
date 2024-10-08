
namespace domain.exceptions.models.iteration.iterationTitle;

/// <summary>
/// Exception for when a Iteration is created with a too short title
/// </summary>
public class IterationTitleTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public IterationTitleTooShortException() : base("Title is too short, it must be more then 3 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public IterationTitleTooShortException(string message) : base(message) { }
}

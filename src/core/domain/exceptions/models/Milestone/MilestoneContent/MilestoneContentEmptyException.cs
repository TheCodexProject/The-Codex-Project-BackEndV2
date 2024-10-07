using System.Runtime.Serialization;

namespace domain.exceptions.milestone.milestoneContent;

/// <summary>
/// Exception for when a Milestone is created without content.
/// </summary>
public class MilestoneContentEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public MilestoneContentEmptyException() : base("Content cannot be empty.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public MilestoneContentEmptyException(string message) : base(message) { }

    /// <summary>
    /// Used for inner exceptions (Like when an exception is thrown inside another exception)
    /// </summary>
    /// <param name="message">Customized message.</param>
    /// <param name="innerException">Inner exception.</param>
    public MilestoneContentEmptyException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Used for serialization.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected MilestoneContentEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
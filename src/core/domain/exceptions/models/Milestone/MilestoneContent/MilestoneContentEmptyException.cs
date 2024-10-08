namespace domain.exceptions.models.milestone.milestonecontent;

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
}
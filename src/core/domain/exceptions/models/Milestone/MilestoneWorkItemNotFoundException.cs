
namespace domain.exceptions.models.milestone;

/// <summary>
/// Exception for when a Project is created without a title.
/// </summary>
public class MilestoneWorkItemNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public MilestoneWorkItemNotFoundException() : base("Workitem not found.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public MilestoneWorkItemNotFoundException(string message) : base(message) { }
}
namespace domain.exceptions.models.milestone.milestonetitle;

/// <summary>
/// An exception for when a Milestone title is too short.
/// </summary>
public class MilestoneTitleTooShortException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public MilestoneTitleTooShortException() : base("Title is too short, it cannot be less than 3 characters.") { }
}
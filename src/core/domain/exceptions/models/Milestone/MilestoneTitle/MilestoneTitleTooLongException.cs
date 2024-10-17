namespace domain.exceptions.models.milestone.milestonetitle;

/// <summary>
/// An exception for when a Milestone title is too long.
/// </summary>
public class MilestoneTitleTooLongException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public MilestoneTitleTooLongException() : base("Title is too long, it cannot be more than 75 characters.") { }
}
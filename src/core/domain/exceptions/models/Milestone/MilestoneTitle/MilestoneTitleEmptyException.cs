namespace domain.exceptions.models.milestone.milestonetitle;

/// <summary>
/// Exception for when a Milestone is created without a title.
/// </summary>
public class MilestoneTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public MilestoneTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }
}
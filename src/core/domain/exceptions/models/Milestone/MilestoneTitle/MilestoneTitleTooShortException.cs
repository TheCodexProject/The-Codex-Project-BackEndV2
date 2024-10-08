namespace domain.exceptions.models.milestone.milestonetitle;

public class MilestoneTitleTooShortException : Exception
{
    public MilestoneTitleTooShortException() : base("Title is too short, it cannot be less than 3 characters.") { }

    public MilestoneTitleTooShortException(string message) : base(message) { }
}
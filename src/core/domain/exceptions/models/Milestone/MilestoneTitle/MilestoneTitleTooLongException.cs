
namespace domain.exceptions.models.milestone.milestonetitle;

public class MilestoneTitleTooLongException : Exception
{
    public MilestoneTitleTooLongException() : base("Title is too long, it cannot be more than 75 characters.") { }

    public MilestoneTitleTooLongException(string message) : base(message) { }
}
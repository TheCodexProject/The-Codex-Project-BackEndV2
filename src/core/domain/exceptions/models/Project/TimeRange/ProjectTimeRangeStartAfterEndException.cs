namespace domain.exceptions.models.project.TimeRange;

/// <summary>
/// An exception used when the start time is after the end time.
/// </summary>
public class ProjectTimeRangeStartAfterEndException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectTimeRangeStartAfterEndException() : base("Start time cannot be after End time.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectTimeRangeStartAfterEndException(string message) : base(message) { }
}
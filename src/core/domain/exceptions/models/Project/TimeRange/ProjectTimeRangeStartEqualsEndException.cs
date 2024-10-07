namespace domain.exceptions.models.project.TimeRange;

/// <summary>
/// An exception used when the project time range start is equal to the end.
/// </summary>
public class ProjectTimeRangeStartEqualsEndException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectTimeRangeStartEqualsEndException() : base("Start and End date cannot be the same day. Please select two different dates and try again.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectTimeRangeStartEqualsEndException(string message) : base(message) { }
}
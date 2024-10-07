namespace domain.exceptions.models.project.TimeRange;

/// <summary>
/// An exception used when the project time range end is before the start.
/// </summary>
public class ProjectTimeRangeEndBeforeStartException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectTimeRangeEndBeforeStartException() : base("End time cannot be before Start time.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectTimeRangeEndBeforeStartException(string message) : base(message) { }
}
namespace domain.exceptions.models.project.timeRange;

/// <summary>
/// An exception for when a Project's time range starts in the past.
/// </summary>
public class ProjectTimeRangeStartInThePastException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectTimeRangeStartInThePastException() : base("Start date cannot be in the Past. Please provide a new Start date and try again.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectTimeRangeStartInThePastException(string message) : base(message) { }

}
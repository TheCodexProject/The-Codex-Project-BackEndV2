namespace domain.exceptions.models.project.timeRange;

/// <summary>
/// An exception for when a Project is created with an invalid time range.
/// </summary>
public class ProjectTimeRangeInvalidException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public ProjectTimeRangeInvalidException() : base("One of the provided dates are not set. Please check that both dates are set and try again.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public ProjectTimeRangeInvalidException(string message) : base(message) { }

}
namespace domain.models.values;

public enum Status
{
    /// <summary>
    /// The work item is not in any status.
    /// </summary>
    None,
    /// <summary>
    /// The work item is open.
    /// </summary>
    Open,
    /// <summary>
    /// The work item is in progress.
    /// </summary>
    InProgress,
    /// <summary>
    /// The work item is ready for review.
    /// </summary>
    ReadyForReview,
    /// <summary>
    /// The work item is done.
    /// </summary>
    Done,

    /// <summary>
    /// The work item is closed.
    /// </summary>
    Closed
}
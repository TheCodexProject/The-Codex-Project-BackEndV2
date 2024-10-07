namespace domain.models.values;

public enum Priority
{
    /// <summary>
    /// The work item has no priority.
    /// </summary>
    None,

    /// <summary>
    /// The work item has a low priority.
    /// </summary>
    Low,

    /// <summary>
    /// The work item has a medium priority.
    /// </summary>
    Medium,

    /// <summary>
    /// The work item has a high priority.
    /// </summary>
    High,

    /// <summary>
    /// The work item has a critical priority.
    /// </summary>
    Critical
}
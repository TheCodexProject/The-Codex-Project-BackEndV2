namespace domain.models.values;

public enum ItemType
{
    /// <summary>
    /// The item is of no specific type. (Default)
    /// </summary>
    None,

    /// <summary>
    /// The item is a bug report
    /// </summary>
    Bug,

    /// <summary>
    /// The item is a story.
    /// </summary>
    Story,

    /// <summary>
    /// The item is a task.
    /// </summary>
    Task,

    /// <summary>
    /// The item is an epic.
    /// </summary>
    Epic
}
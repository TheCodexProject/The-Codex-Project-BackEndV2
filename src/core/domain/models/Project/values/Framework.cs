namespace domain.models.project.values;

public enum Framework
{
    /// <summary>
    /// The project either haven't decided on an framework or doesn't use one.
    /// </summary>
    None,

    /// <summary>
    /// The project uses an Agile model as its framework.
    /// </summary>
    Agile,

    /// <summary>
    /// The project uses Waterfall model as its framework.
    /// </summary>
    Waterfall,

    /// <summary>
    /// The project uses Kanban as its framework.
    /// </summary>
    Kanban,

    /// <summary>
    /// The project uses Scrum as its framework.
    /// </summary>
    Scrum,
}
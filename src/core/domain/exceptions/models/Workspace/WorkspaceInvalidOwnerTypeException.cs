namespace domain.exceptions.models.Workspace;

/// <summary>
/// An exception for when the provided owner type does not match the owner type of the workspace.
/// </summary>
public class WorkspaceInvalidOwnerTypeException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public WorkspaceInvalidOwnerTypeException() : base("The provided owner type does not match the owner type of the workspace.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public WorkspaceInvalidOwnerTypeException(string message) : base(message) { }
}


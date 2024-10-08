namespace domain.exceptions.models.organisation;

/// <summary>
/// Exception for when an documentation entity is already created and cannot be created again.
/// </summary>
public class OrganisationDocumentationAlreadyExistsException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationDocumentationAlreadyExistsException() : base("Documentation was not found.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationDocumentationAlreadyExistsException(string message) : base(message) { }
}
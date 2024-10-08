namespace domain.exceptions.models.organisation;

/// <summary>
/// Exception for when an documentation entity cannot be found.
/// </summary>
public class OrganisationDocumentationNotFoundException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationDocumentationNotFoundException() : base("Documentation was not found.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationDocumentationNotFoundException(string message) : base(message) { }
}
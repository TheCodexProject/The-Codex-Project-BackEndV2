using System.Runtime.Serialization;

namespace domain.exceptions.orgamodels.organisationnisation;

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
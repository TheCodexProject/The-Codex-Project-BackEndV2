using System.Runtime.Serialization;

namespace domain.exceptions.models.organisation;

[Serializable]
public class OrganisationOwnerNotFoundException :Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationOwnerNotFoundException() : base("The given Owner was not found for the Organisation.") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationOwnerNotFoundException(string message) : base(message) { }

}
using System.Runtime.Serialization;

namespace domain.exceptions.models.organisation;

[Serializable]
public class OrganisationNeedsAnOwnerException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationNeedsAnOwnerException() : base("The Organisation needs atleast 1 Owner") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationNeedsAnOwnerException(string message) : base(message) { }
}
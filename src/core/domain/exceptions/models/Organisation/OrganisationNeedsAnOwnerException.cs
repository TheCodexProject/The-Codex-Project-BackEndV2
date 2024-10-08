namespace domain.exceptions.models.organisation;

/// <summary>
/// Exception for when a someone tries to remove an owner from an organisation that only has 1 owner.
/// </summary>
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
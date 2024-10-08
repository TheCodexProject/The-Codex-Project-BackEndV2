namespace domain.exceptions.models.organisation;

/// <summary>
/// Exception for when a someone tries to add an owner that cannot be found.
/// </summary>
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
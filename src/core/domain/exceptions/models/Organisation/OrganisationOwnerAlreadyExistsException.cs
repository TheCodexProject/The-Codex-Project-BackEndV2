namespace domain.exceptions.models.organisation;

/// <summary>
/// Exception for when a someone tries to add an owner .
/// </summary>
public class OrganisationOwnerAlreadyExistsException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationOwnerAlreadyExistsException() : base("The given User is already an owner of this organisation") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationOwnerAlreadyExistsException(string message) : base(message) { }
}
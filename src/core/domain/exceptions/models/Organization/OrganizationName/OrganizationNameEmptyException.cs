namespace domain.exceptions.models.organization.organizationname;

/// <summary>
/// Exception for when an Organization is created without a title.
/// </summary>
public class OrganizationNameEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganizationNameEmptyException() : base("Name cannot be empty, it must be between 2 and 100 characters.") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganizationNameEmptyException(string message) : base(message) { }
}
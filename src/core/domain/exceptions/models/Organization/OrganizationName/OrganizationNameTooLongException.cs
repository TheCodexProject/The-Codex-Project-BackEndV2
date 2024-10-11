namespace domain.exceptions.models.organization.organizationname;

/// <summary>
/// Exception for when an Organization is created with a title that's too long.
/// </summary>
public class OrganizationNameTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganizationNameTooLongException() : base("Name is too long, it cannot be more than 100 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganizationNameTooLongException(string message) : base(message) { }
}
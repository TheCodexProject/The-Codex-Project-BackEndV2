namespace domain.exceptions.models.organization.organizationname;

/// <summary>
/// Exception for when an Organization is created with a title that's too short.
/// </summary>
public class OrganizationNameTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganizationNameTooShortException() : base("Name is too short, it cannot be less than 2 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganizationNameTooShortException(string message) : base(message) { }
}
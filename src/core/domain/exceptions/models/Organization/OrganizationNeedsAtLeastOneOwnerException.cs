namespace domain.exceptions.models.Organization;

/// <summary>
/// An exception that is thrown when a user tries to remove all owners for an organization. (There always needs to be at least one owner)
/// </summary>
public class OrganizationNeedsAtLeastOneOwnerException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganizationNeedsAtLeastOneOwnerException() : base("An organization has to have at least one owner.") { }
}
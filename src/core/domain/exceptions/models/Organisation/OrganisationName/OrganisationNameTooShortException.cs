namespace domain.exceptions.models.organisation;

/// <summary>
/// Exception for when an Organisation is created with a title that's too short.
/// </summary>
public class OrganisationNameTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationNameTooShortException() : base("Title is too short, it cannot be less than 2 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationNameTooShortException(string message) : base(message) { }
}
namespace domain.exceptions.models.organisation;

/// <summary>
/// Exception for when an Organisation is created with a title that's too long.
/// </summary>
public class OrganisationNameTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationNameTooLongException() : base("Title is too long, it cannot be more than 100 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationNameTooLongException(string message) : base(message) { }
}
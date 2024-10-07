using System.Runtime.Serialization;

namespace domain.exceptions.models.organisation;

/// <summary>
/// Exception for when an Organisation is created without a title.
/// </summary>
public class OrganisationNameEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrganisationNameEmptyException() : base("Title cannot be empty, it must be between 2 and 100 characters.") { }
    
    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrganisationNameEmptyException(string message) : base(message) { }
}
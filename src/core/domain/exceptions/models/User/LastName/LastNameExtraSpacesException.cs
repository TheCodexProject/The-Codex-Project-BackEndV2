namespace domain.exceptions.models.user.lastname;

/// <summary>
/// An exception for when a last name contains extra spaces.
/// </summary>
public class LastNameExtraSpacesException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public LastNameExtraSpacesException() : base("Your first name can not contain extra spaces. Please remove the extra spaces and try again." ) { }
}
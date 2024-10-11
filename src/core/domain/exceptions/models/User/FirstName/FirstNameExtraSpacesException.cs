namespace domain.exceptions.models.user.FirstName;

/// <summary>
/// An exception for when a first name contains extra spaces.
/// </summary>
public class FirstNameExtraSpacesException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public FirstNameExtraSpacesException() : base("Your first name can not contain extra spaces. Please remove the extra spaces and try again." ) { }
}
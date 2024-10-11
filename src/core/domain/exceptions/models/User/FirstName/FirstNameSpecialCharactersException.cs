namespace domain.exceptions.models.user.FirstName;

/// <summary>
/// An exception for when a first name contains special characters.
/// </summary>
public class FirstNameSpecialCharactersException : Exception
{
    /// <summary>
    /// Default message
    /// </summary>
    public FirstNameSpecialCharactersException() : base("Your first name can not contain special characters. Please remove the special characters and try again." ) { }
}
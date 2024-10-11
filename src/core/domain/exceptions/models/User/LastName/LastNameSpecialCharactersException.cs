namespace domain.exceptions.models.user.lastname;

/// <summary>
/// An exception for when a last name contains special characters.
/// </summary>
public class LastNameSpecialCharactersException : Exception
{
    /// <summary>
    /// Default message
    /// </summary>
    public LastNameSpecialCharactersException() : base("Your last name can not contain special characters. Please remove the special characters and try again." ) { }
}
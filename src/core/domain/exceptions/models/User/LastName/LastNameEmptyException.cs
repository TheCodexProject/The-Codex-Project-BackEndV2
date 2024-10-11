namespace domain.exceptions.models.user.lastname;


/// <summary>
/// An exception for when a user is created without a last name.
/// </summary>
public class LastNameEmptyException : Exception
{
    /// <summary>
    /// Default message
    /// </summary>
    public LastNameEmptyException() : base("Your last name is missing. Please provide your last name." ) { }
}
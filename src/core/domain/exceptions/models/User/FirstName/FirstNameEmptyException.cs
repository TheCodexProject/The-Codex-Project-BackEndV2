namespace domain.exceptions.models.user.FirstName;

/// <summary>
/// An exception for when a user is created without a first name.
/// </summary>
public class FirstNameEmptyException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public FirstNameEmptyException() : base("Your first name is missing. Please provide your first name." ) { }
}
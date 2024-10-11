namespace domain.exceptions.models.user.FirstName;

/// <summary>
/// An exception for when a user's first name is too short.
/// </summary>
public class FirstNameTooShortException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public FirstNameTooShortException() : base("Your first name is too short. Please enter at least 2 characters." ) { }
}
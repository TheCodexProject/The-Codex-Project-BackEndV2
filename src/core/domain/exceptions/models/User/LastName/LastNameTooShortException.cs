namespace domain.exceptions.models.user.lastname;

/// <summary>
/// An exception for when a user's last name is too short.
/// </summary>
public class LastNameTooShortException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public LastNameTooShortException() : base("Your last name is too short. Please enter at least 2 characters." ) { }
}
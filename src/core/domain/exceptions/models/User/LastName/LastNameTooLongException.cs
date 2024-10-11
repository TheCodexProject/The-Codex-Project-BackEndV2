namespace domain.exceptions.models.user.LastName;

/// <summary>
/// An exception for when a user's last name is too long.
/// </summary>
public class LastNameTooLongException : Exception
{
    /// <summary>
    /// Default message
    /// </summary>
    public LastNameTooLongException() : base("Your last name is too long. Please enter a last name with no more than 60 characters." ) { }
}
namespace domain.exceptions.models.user.email;

/// <summary>
/// An exception for when a user is created without an email.
/// </summary>
public class EmailEmptyException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public EmailEmptyException() : base("Email is empty, please provide an email.") { }

}
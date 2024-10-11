namespace domain.exceptions.models.user.email;

/// <summary>
/// An exception for when an email is invalid.
/// </summary>
public class EmailInvalidException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public EmailInvalidException() : base("Email is invalid, please provide a valid email.") { }
}
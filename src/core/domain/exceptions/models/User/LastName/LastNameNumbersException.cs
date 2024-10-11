namespace domain.exceptions.models.user.lastname;

/// <summary>
/// An exception for when a last name contains numbers.
/// </summary>
public class LastNameNumbersException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public LastNameNumbersException() : base("Your last name can not contain numbers. Please remove the numbers and try again." ) { }
}
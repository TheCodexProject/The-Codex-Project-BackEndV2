namespace domain.exceptions.models.user.firstname;

/// <summary>
/// An exception for when a first name contains numbers.
/// </summary>
public class FirstNameNumbersException : Exception
{
    /// <summary>
    /// Default message
    /// </summary>
    public FirstNameNumbersException() : base("Your first name can not contain numbers. Please remove the numbers and try again." ) { }
}
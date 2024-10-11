using System.Runtime.Serialization;
namespace domain.exceptions.models.user.FirstName;

/// <summary>
/// An exception for when a user's first name is too long.
/// </summary>
public class FirstNameTooLongException : Exception
{
    /// <summary>
    /// Default message.
    /// </summary>
    public FirstNameTooLongException() : base("Your first name is too long. Please enter a first name with no more than 50 characters." ) { }
}
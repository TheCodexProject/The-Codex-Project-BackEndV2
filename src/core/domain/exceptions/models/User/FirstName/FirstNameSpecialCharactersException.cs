namespace domain.exceptions.models.user.FirstName;

public class FirstNameSpecialCharactersException : Exception
{
    public FirstNameSpecialCharactersException() : base("Your first name can not contain special characters. Please remove the special characters and try again." ) { }

    public FirstNameSpecialCharactersException(string message) : base(message) { }
}
namespace domain.exceptions.models.user.LastName;

public class LastNameSpecialCharactersException : Exception
{
    public LastNameSpecialCharactersException() : base("Your last name can not contain special characters. Please remove the special characters and try again." ) { }

    public LastNameSpecialCharactersException(string message) : base(message) { }
}
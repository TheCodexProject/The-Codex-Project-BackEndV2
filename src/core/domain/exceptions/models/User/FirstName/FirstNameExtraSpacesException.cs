namespace domain.exceptions.models.user.FirstName;

public class FirstNameExtraSpacesException : Exception
{
    public FirstNameExtraSpacesException() : base("Your first name can not contain extra spaces. Please remove the extra spaces and try again." ) { }

    public FirstNameExtraSpacesException(string message) : base(message) { }
}
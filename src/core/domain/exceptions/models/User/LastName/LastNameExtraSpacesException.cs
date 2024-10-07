namespace domain.exceptions.models.user.LastName;

public class LastNameExtraSpacesException : Exception
{
    public LastNameExtraSpacesException() : base("Your first name can not contain extra spaces. Please remove the extra spaces and try again." ) { }

    public LastNameExtraSpacesException(string message) : base(message) { }
}
namespace domain.exceptions.models.user.FirstName;

public class FirstNameNumbersException : Exception
{
    public FirstNameNumbersException() : base("Your first name can not contain numbers. Please remove the numbers and try again." ) { }
    
    public FirstNameNumbersException(string message) : base(message) { }
}
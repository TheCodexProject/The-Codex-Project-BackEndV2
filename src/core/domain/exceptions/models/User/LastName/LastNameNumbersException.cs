namespace domain.exceptions.models.user.LastName;

public class LastNameNumbersException : Exception
{
    public LastNameNumbersException() : base("Your last name can not contain numbers. Please remove the numbers and try again." ) { }
    
    public LastNameNumbersException(string message) : base(message) { }
}
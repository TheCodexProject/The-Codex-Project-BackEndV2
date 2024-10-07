using System.Text.RegularExpressions;
using domain.exceptions.models.user.Email;
using domain.exceptions.models.user.FirstName;
using domain.exceptions.models.user.LastName;
using OperationResult;

namespace domain.models.user;

public static class UserValidator
{
    public static Result<string> ValidateFirstName(string firstName)
    {
        if(string.IsNullOrWhiteSpace(firstName))
        {
            return Result<string>.Failure(new FirstNameEmptyException());
        }

        if (ContainsNumbers(firstName))
        {
            return Result<string>.Failure(new FirstNameNumbersException());
        }

        if (ContainsSpecialCharacters(firstName))
        {
            return Result<string>.Failure(new FirstNameSpecialCharactersException());
        }

        if (ContainsExtraSpaces(firstName))
        {
            return Result<string>.Failure(new FirstNameExtraSpacesException());
        }

        if (firstName.Length < 2)
        {
            return Result<string>.Failure(new FirstNameTooShortException());
        }

        if (firstName.Length > 50)
        {
            return Result<string>.Failure(new FirstNameTooLongException());
        }

        return Result<string>.Success(firstName);
    }

    public static Result<string> ValidateLastName(string lastName)
    {
        if(string.IsNullOrWhiteSpace(lastName))
        {
            return Result<string>.Failure(new LastNameEmptyException());
        }

        if(ContainsNumbers(lastName))
        {
            return Result<string>.Failure(new LastNameNumbersException());
        }

        if(ContainsSpecialCharacters(lastName))
        {
            return Result<string>.Failure(new LastNameSpecialCharactersException());
        }

        if(ContainsExtraSpaces(lastName))
        {
            return Result<string>.Failure(new LastNameExtraSpacesException());
        }

        if(lastName.Length < 2)
        {
            return Result<string>.Failure(new LastNameTooShortException());
        }

        if(lastName.Length > 60)
        {
            return Result<string>.Failure(new LastNameTooLongException());
        }

        return Result<string>.Success(lastName);
    }

    private static bool ContainsSpecialCharacters(string value)
    {
        const string pattern = @"[^a-zA-Z\s-']";
        return Regex.IsMatch(value, pattern);
    }



    private static bool ContainsNumbers(string value)
    {
        const string pattern = @"\d";
        return Regex.IsMatch(value, pattern);
    }

    private static bool ContainsExtraSpaces(string value)
    {
        const string pattern = @"(^\s|\s{2,}|\s$)";
        return Regex.IsMatch(value, pattern);
    }


    public static Result<string> ValidateEmail(string email)
    {
        if(string.IsNullOrWhiteSpace(email))
        {
            return Result<string>.Failure(new EmailEmptyException());
        }

        if(!EmailFormatCheck(email))
        {
            return Result<string>.Failure(new EmailInvalidException());
        }

        return Result<string>.Success(email);
    }

    /// <summary>
    /// Helper method to check the basic format of an email.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static bool EmailFormatCheck(string value)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        if (!Regex.IsMatch(value, pattern))
        {
            return false;
        }

        var parts = value.Split('@');
        if (parts.Length != 2)
        {
            return false;
        }

        var localPart = parts[0];
        var domainPart = parts[1];

        if (localPart.Length > 30 || value.Length > 254)
        {
            return false;
        }

        if (localPart.Contains("..") || domainPart.Contains(".."))
        {
            return false;
        }

        if (localPart.StartsWith(".") || localPart.EndsWith("."))
        {
            return false;
        }

        var domainParts = domainPart.Split('.');
        if (domainParts.Any(part => part.Length > 63))
        {
            return false;
        }


        return true;
    }
}
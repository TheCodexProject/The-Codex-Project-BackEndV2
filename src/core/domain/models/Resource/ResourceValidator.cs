using domain.exceptions.common;
using domain.exceptions.models.resource.Format;
using domain.exceptions.models.resource.Reference;
using domain.exceptions.models.resource.Title;
using OperationResult;

namespace domain.models.resource;

public static class ResourceValidator
{
    public static Result<string> ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result<string>.Failure(new ResourceTitleEmptyException());
        }

        if (title.Length < 3)
        {
            return Result<string>.Failure(new ResourceTitleTooShortException());
        }

        if (title.Length > 75)
        {
            return Result<string>.Failure(new ResourceTitleTooLongException());
        }

        return Result<string>.Success(title);
    }

    public static Result<string> ValidateFormat(string format)
    {
        if (string.IsNullOrWhiteSpace(format))
        {
            return Result<string>.Failure(new ResourceFormatEmptyException());
        }

        if (!format.Contains('.'))
        {
            return Result<string>.Failure(new ResourceFormatInvalidException("The format must contain a dot."));
        }

        if(!format.StartsWith('.'))
        {
            return Result<string>.Failure(new ResourceFormatInvalidException("The format must always start with a dot."));
        }

        if(!ContainsValidNumberOfDots(format))
        {
            return Result<string>.Failure(new ResourceFormatInvalidException("The format must contain only one dot."));
        }

        if (format.Length < 2)
        {
            return Result<string>.Failure(new ResourceFormatTooShortException());
        }

        if (format.Length > 10)
        {
            return Result<string>.Failure(new ResourceFormatTooLongException());
        }

        return Result<string>.Success(format);
    }

    private static bool ContainsValidNumberOfDots(string format)
    {
        var dots = format.Count(c => c == '.');
        return dots == 1;
    }

    public static Result<string> ValidateReference(string reference)
    {
        if (string.IsNullOrWhiteSpace(reference))
        {
            return Result<string>.Failure(new ResourceReferenceEmptyException());
        }

        if (reference.Length > 200)
        {
            return Result<string>.Failure(new ResourceReferenceTooLongException());
        }

        return Result<string>.Success(reference);
    }
}
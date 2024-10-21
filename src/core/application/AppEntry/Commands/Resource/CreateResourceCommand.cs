using OperationResult;
using domain.models.resource;

namespace application.AppEntry.Commands.resource;

public class CreateResourceCommand
{
    public Guid Id { get; set; }

    public string? title { get; }

    public string? format { get; }

    public string? reference { get; }

    public CreateResourceCommand(string title, string format, string reference)
    {
        this.title = title;
        this.format = format;
        this.reference = reference;
    }

    public static Result<CreateResourceCommand> Create(string? title, string? format, string? refrence)
    {
        var resourceTitleResult = ResourceValidator.ValidateTitle(title);
        var resourceFormatResult = ResourceValidator.ValidateFormat(format);
        var resourceReferenceResult = ResourceValidator.ValidateReference(refrence);

        if (resourceTitleResult.IsSuccess & resourceFormatResult.IsSuccess & resourceReferenceResult.IsSuccess)
        {
            return Result<CreateResourceCommand>.Success(new CreateResourceCommand(title!, format!, refrence!));
        }

        List<Exception> errors = [];
        errors.AddRange(resourceTitleResult.Errors);
        errors.AddRange(resourceFormatResult.Errors);
        errors.AddRange(resourceReferenceResult.Errors);
        return Result<CreateResourceCommand>.Failure(errors.ToArray());
    }
}

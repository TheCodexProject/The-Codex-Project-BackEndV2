using domain.models.resource;
using OperationResult;

namespace application.AppEntry.Commands.resource;

public class UpdateResourceCommand
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Format { get; set; }
    public string? Reference { get; set; }
    public UpdateResourceCommand(Guid id, string? title, string? format, string? reference)
    {
        this.Id = id;
        this.Title = title;
        this.Format = format;
        this.Reference = reference;
    }

    public static Result<UpdateResourceCommand> Create(string id, string? title, string? format, string? reference)
    {
        // Validate that the input is a valid GUID
        if (!Guid.TryParse(id, out Guid parsedId))
        {
            return Result<UpdateResourceCommand>.Failure(new Exception("Invalid GUID format for Id."));
        }

        var resourceTitleResult = ResourceValidator.ValidateTitle(title);
        var resourceFormatResult = ResourceValidator.ValidateFormat(format);
        var resourceReferenceResult = ResourceValidator.ValidateReference(reference);

        if (resourceTitleResult.IsSuccess & resourceFormatResult.IsSuccess & resourceReferenceResult.IsSuccess)
        {
            return Result<UpdateResourceCommand>.Success(new UpdateResourceCommand(parsedId, title, format, reference));
        }

        List<Exception> errors = [];
        errors.AddRange(resourceTitleResult.Errors);
        errors.AddRange(resourceFormatResult.Errors);
        errors.AddRange(resourceReferenceResult.Errors);
        return Result<UpdateResourceCommand>.Failure(errors.ToArray());
    }
}

using domain.models.board;
using OperationResult;

namespace application.appEntry.commands.board;

public class UpdateBoardCommand
{
    public Guid Id { get; set; }
    public string? Title { get; set; }

    public UpdateBoardCommand(Guid id, string? title)
    {
        this.Id = id;
        this.Title = title;
    }

    public static Result<UpdateBoardCommand> Create(string id, string? title)
    {
        // Validate that the input is a valid GUID
        if (!Guid.TryParse(id, out Guid parsedId))
        {
            return Result<UpdateBoardCommand>.Failure(new Exception("Invalid GUID format for Id."));
        }

        List<Exception> errors = [];
        if (title != null)
        {
            var workspaceTitleResult = BoardValidator.ValidateTitle(title);

            if (workspaceTitleResult.IsSuccess)
            {
                return Result<UpdateBoardCommand>.Success(new UpdateBoardCommand(parsedId, title));
            }

            errors.AddRange(workspaceTitleResult.Errors);
        }
        return Result<UpdateBoardCommand>.Failure(errors.ToArray());
    }
}

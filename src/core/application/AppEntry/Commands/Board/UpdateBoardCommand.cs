
using domain.models.board;
using OperationResult;

namespace application.appEntry.commands.board;

public class UpdateBoardCommand
{
    public string id { get; set; }
    public string? title { get; set; }

    public UpdateBoardCommand(string Id, string? Title)
    {
        this.id = Id;
        this.title = Title;
    }

    public static Result<UpdateBoardCommand> Create(string Id, string? Title)
    {
        var workspaceTitleResult = BoardValidator.ValidateTitle(Title);

        if (workspaceTitleResult.IsSuccess)
        {
            return Result<UpdateBoardCommand>.Success(new UpdateBoardCommand(Id, Title));
        }

        List<Exception> errors = [];
        errors.AddRange(workspaceTitleResult.Errors);
        return Result<UpdateBoardCommand>.Failure(errors.ToArray());
    }
}

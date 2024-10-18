using OperationResult;
using domain.models.board;

namespace application.appEntry.commands.board;

public class CreateBoardCommand
{
    public string title { get; }
    public Guid Id { get; set; }

    public CreateBoardCommand(string title)
    {
        this.title = title;
    }

    public static Result<CreateBoardCommand> Create(string? title)
    {
        var workspaceTitleResult = BoardValidator.ValidateTitle(title);

        if (workspaceTitleResult.IsSuccess)
        {
            return Result<CreateBoardCommand>.Success(new CreateBoardCommand(title!));
        }

        List<Exception> errors = [];
        errors.AddRange(workspaceTitleResult.Errors);
        return Result<CreateBoardCommand>.Failure(errors.ToArray());
    }
}

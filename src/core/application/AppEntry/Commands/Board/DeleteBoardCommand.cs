using domain.models.board;
using OperationResult;

namespace application.appEntry.commands.board;

public class DeleteBoardCommand
{
    public Guid Id { get; set; }

    public DeleteBoardCommand(Guid id)
    {
        this.Id = id;
    }

    public static Result<DeleteBoardCommand> Create(string id)
    {
        // Validate that the input is a valid GUID
        if (!Guid.TryParse(id, out Guid parsedId))
        {
            return Result<DeleteBoardCommand>.Failure(new Exception("Invalid GUID format for Id."));
        }

        // Return a successful result with the created command
        return Result<DeleteBoardCommand>.Success(new DeleteBoardCommand(parsedId));
    }
}
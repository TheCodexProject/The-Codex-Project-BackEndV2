
using OperationResult;

namespace application.appEntry.commands.board;

public class ReadBoardCommand
{
    public Guid Id { get; set; }
    public string? Title { get; set; }

    public ReadBoardCommand(Guid id)
    {
        this.Id = id;
    }

    public static Result<ReadBoardCommand> Create(string id)
    {
        // Validate that the input is a valid GUID
        if (!Guid.TryParse(id, out Guid parsedId))
        {
            return Result<ReadBoardCommand>.Failure(new Exception("Invalid GUID format for Id."));
        }

        // Return a successful result with the created command
        return Result<ReadBoardCommand>.Success(new ReadBoardCommand(parsedId));
    }
}

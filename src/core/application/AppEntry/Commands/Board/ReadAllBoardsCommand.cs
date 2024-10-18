using domain.models.board;
using OperationResult;


namespace application.appEntry.commands.board;

public class ReadAllBoardsCommand
{
    public IEnumerable<Board>? Boards { get; set; }

    public ReadAllBoardsCommand()
    {
     
    }

    public static Result<ReadAllBoardsCommand> Create()
    {
        // Return a successful result with the created command
        return Result<ReadAllBoardsCommand>.Success(new ReadAllBoardsCommand());
    }
}

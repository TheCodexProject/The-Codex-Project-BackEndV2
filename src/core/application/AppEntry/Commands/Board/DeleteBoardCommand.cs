using OperationResult;

namespace application.appEntry.commands.board;

public class DeleteBoardCommand
{

    public DeleteBoardCommand()
    {

    }

    public static Result<DeleteBoardCommand> Create()
    {        
        return Result<DeleteBoardCommand>.Success(new DeleteBoardCommand());   
    }
}

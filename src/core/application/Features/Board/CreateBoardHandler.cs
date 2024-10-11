using application.AppEntry.Interfaces;
using application.appEntry.commands.board;
using OperationResult;
using domain.interfaces;
using domain.models.board;

namespace application.features.board;

public class CreateBoardHandler(IRepository<Board> repository) : ICommandHandler<CreateBoardCommand>
{
    public async Task<Result> HandleAsync(CreateBoardCommand command)
    {
        var board = Board.Create();
        board.UpdateTitle(command.title);

        await repository.AddAsync(board);

        command.Id = board.Uid;

        return Result.Success();
    }
}


using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using domain.interfaces;
using domain.models.board;
using OperationResult;

namespace application.features.board;

public class DeleteBoardHandler(IRepository<Board> repository) : ICommandHandler<DeleteBoardCommand>
{
    public Task<Result> HandleAsync(DeleteBoardCommand command)
    {
        throw new NotImplementedException();
    }
}


using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using domain.interfaces;
using domain.models.board;
using OperationResult;

namespace application.features.board;

public class ReadBoardHandler(IRepository<Board> repository) : ICommandHandler<ReadBoardCommand>
{
    public Task<Result> HandleAsync(ReadBoardCommand command)
    {
        throw new NotImplementedException();
    }
}

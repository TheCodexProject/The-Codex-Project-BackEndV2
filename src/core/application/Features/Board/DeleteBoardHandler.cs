
using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using domain.exceptions.common;
using domain.interfaces;
using domain.models.board;
using OperationResult;

namespace application.features.board;

public class DeleteBoardHandler(IUnitOfWork unitOfWork) : ICommandHandler<DeleteBoardCommand>
{
    public async Task<Result> HandleAsync(DeleteBoardCommand command)
    {
        Guid id = command.id;
        Board board = await unitOfWork.Boards.GetByIdAsync(id);

        if (board == null)
        {
            return Result.Failure(new NotFoundException("Board not found."));
        }




        await repository.Delete(id);
        return Result.Success();
    }
}

using application.AppEntry.Interfaces;
using application.appEntry.commands.board;
using OperationResult;
using domain.interfaces;
using domain.models.board;

namespace application.features.board;

public class CreateBoardHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateBoardCommand>
{
    public async Task<Result> HandleAsync(CreateBoardCommand command)
    {
        try
        {
            var board = Board.Create();
            board.UpdateTitle(command.title);

            await unitOfWork.Boards.AddAsync(board);
            await unitOfWork.SaveChangesAsync();

            command.Id = board.Uid;

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new ApplicationException("An error occurred while creating the board.", ex));
        }
    }
}


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
        try
        { 
            Board board = await unitOfWork.Boards.GetByIdAsync(command.Id);

            if (board == null)
            {
                return Result.Failure(new NotFoundException("Board not found."));
            }

            unitOfWork.Boards.Remove(board);
            await unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            // Log the exception as needed.
            return Result.Failure(new ApplicationException("An error occurred while trying to delete the board.", ex));
        }
    }
}

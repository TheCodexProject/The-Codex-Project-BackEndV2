
using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using domain.interfaces;
using domain.models.board;
using OperationResult;
using domain.exceptions.common;

namespace application.features.board;

public class UpdateBoardHandler(IUnitOfWork unitOfWork) : ICommandHandler<UpdateBoardCommand>
{

    public async Task<Result> HandleAsync(UpdateBoardCommand command)
    {
        try
        {
            // Retrieve the board to update
            Board? board = await unitOfWork.Boards.GetByIdAsync(command.Id);

            // Check if the board exists
            if (board == null)
            {
                return Result.Failure(new NotFoundException("Board not found."));
            }

            if (command.Title != null)
            {
                board.UpdateTitle(command.Title);
            }

            await unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            // Log the exception if needed
            return Result.Failure(new ApplicationException("An error occurred while updating the board.", ex));
        }
    }
}

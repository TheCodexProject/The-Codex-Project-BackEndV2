using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using domain.exceptions.common;
using domain.models.board;
using OperationResult;
using domain.interfaces;

namespace application.features.board;

public class ReadAllBoardsHandler(IUnitOfWork unitOfWork) : ICommandHandler<ReadAllBoardCommand>
{
    public async Task<Result> HandleAsync(ReadAllBoardCommand command)
    {
        try
        {
            IEnumerable<Board> boards = await unitOfWork.Boards.GetAllAsync();

            if (boards == null)
            {
                return Result.Failure(new NotFoundException("Boards not found."));
            }

            command.Boards = boards;

            return Result.Success();
        }
        catch (Exception ex)
        {
            // Log the exception as needed.
            return Result.Failure(new ApplicationException("An error occurred while trying to read the boards.", ex));
        }
    }
}

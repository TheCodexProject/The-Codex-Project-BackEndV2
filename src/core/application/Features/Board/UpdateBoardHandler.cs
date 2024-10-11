
using application.appEntry.commands.board;
using application.AppEntry.Interfaces;
using domain.interfaces;
using domain.models.board;
using domain.models.project;
using OperationResult;
using domain.exceptions.common;

namespace application.features.board;

public class UpdateBoardHandler(IRepository<Board> repository) : ICommandHandler<UpdateBoardCommand>
{

    public async Task<Result> HandleAsync(UpdateBoardCommand command)
    {
          var id = int.Parse(command.id);
          Board board = await repository.GetByIdAsync(id);

          if (board == null)
          {
            return Result.Failure(new NotFoundException("Board not found."));
          }

          if (command.title != null)
          {
              board.UpdateTitle(command.title);
          }

          await repository.AddAsync(board);
          return Result.Success();
       }
    }
}

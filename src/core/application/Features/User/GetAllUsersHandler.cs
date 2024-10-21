using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using domain.exceptions.common;
using domain.interfaces;
using OperationResult;

namespace application.Features.user;

public class GetAllUsersHandler(IUnitOfWork unitOfWork) : ICommandHandler<GetAllUsersCommand>
{
    public async Task<Result> HandleAsync(GetAllUsersCommand command)
    {
        // * Get all users
        var users = await unitOfWork.Users.GetAllAsync();

        // ? Were there any users?
        var userList = users.ToList();
        if (!userList.Any())
        {
            return Result.Failure(new NotFoundException("No users were found in the database."));
        }

        // * Set the users on Command.
        command.Users = userList;

        // * Return the users
        return Result.Success();
    }
}
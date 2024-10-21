using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using domain.exceptions.common;
using domain.interfaces;
using OperationResult;

namespace application.Features.user;

public class GetUserHandler(IUnitOfWork unitOfWork) : ICommandHandler<GetUserCommand>
{
    public async Task<Result> HandleAsync(GetUserCommand command)
    {
        // * Get the user from the database
        var user = await unitOfWork.Users.GetByIdAsync(command.Uid);

        // ? Was the user found?
        if (user == null)
            return Result.Failure(new NotFoundException("The user could not be found"));

        // * Set the user's properties on the command
        command.FirstName = user.FirstName;
        command.LastName = user.LastName;
        command.Email = user.Email;

        // * Return success
        return Result.Success();
    }
}
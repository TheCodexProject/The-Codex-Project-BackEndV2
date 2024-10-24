using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using domain.exceptions.common;
using domain.interfaces;
using OperationResult;

namespace application.Features.user;

public class DeleteUserHandler(IUnitOfWork unitOfWork) : ICommandHandler<DeleteUserCommand>
{
    public async Task<Result> HandleAsync(DeleteUserCommand command)
    {
        // ? Does the user exist?
        var user = await unitOfWork.Users.GetByIdAsync(command.Uid);

        // ? If the user does not exist
        if (user == null)
            return Result.Failure(new NotFoundException("The given user could not be found"));

        // * Delete the user
        unitOfWork.Users.Remove(user);

        // ? Was the user deleted?
        if (await unitOfWork.SaveChangesAsync() == 0)
            return Result.Failure(new FailedOperationException("User could not be deleted"));


        // * Return success
        return Result.Success();
    }
}
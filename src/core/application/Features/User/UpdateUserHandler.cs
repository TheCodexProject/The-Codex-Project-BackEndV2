using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using domain.exceptions.common;
using domain.interfaces;
using OperationResult;

namespace application.Features.user;

public class UpdateUserHandler(IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> HandleAsync(UpdateUserCommand command)
    {
        // * Get the user in question from the database using the UID
        var existingUser = await unitOfWork.Users.GetByIdAsync(command.Uid);

        // ! If the user does not exist, return an error
        if (existingUser == null)
            return Result.Failure(new NotFoundException("The user with the given UID does not exist"));

        // * Update the user's information (only if there are changes)
        if (command.FirstName != null)
            existingUser.UpdateFirstName(command.FirstName);

        if (command.LastName != null)
            existingUser.UpdateLastName(command.LastName);

        if (command.Email != null)
            existingUser.UpdateEmail(command.Email);

        // * Update the user's information on the command
        command.FirstName = existingUser.FirstName;
        command.LastName = existingUser.LastName;
        command.Email = existingUser.Email;

        // * Save the changes to the database
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
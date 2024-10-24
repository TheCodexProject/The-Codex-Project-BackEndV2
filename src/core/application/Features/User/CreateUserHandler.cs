using application.AppEntry.Commands.user;
using application.AppEntry.Interfaces;
using domain.exceptions.common;
using domain.interfaces;
using domain.models.user;
using OperationResult;

namespace application.Features.user;

public class CreateUserHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand>
{
    public async Task<Result> HandleAsync(CreateUserCommand command)
    {
        // * Create a new user
        var user = User.Create();

        // * Set the user's properties
        user.UpdateFirstName(command.FirstName);
        user.UpdateLastName(command.LastName);
        user.UpdateEmail(command.Email);

        // * Save the user to the database
        await unitOfWork.Users.AddAsync(user);

        // ? Did the user get saved?
        if (await unitOfWork.SaveChangesAsync() == 0)
            return Result.Failure(new FailedOperationException("Failed to save the user to the database"));

        // * Set the User's ID on the command
        command.Uid = user.Uid;

        // * Return success
        return Result.Success();
    }
}
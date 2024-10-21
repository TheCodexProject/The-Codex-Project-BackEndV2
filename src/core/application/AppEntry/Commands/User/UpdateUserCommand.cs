using domain.exceptions.common;
using domain.models.user;
using OperationResult;

namespace application.AppEntry.Commands.user;

/// <summary>
/// The command used for updating already existing users within the system.
/// </summary>
public class UpdateUserCommand
{
    public Guid Uid { get; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }

    private UpdateUserCommand(Guid uid, string? firstName, string? lastName, string? email)
    {
        Uid = uid;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    /// <summary>
    /// Creates the command to update a user.
    /// </summary>
    /// <param name="uid">Uid to update.</param>
    /// <param name="firstName">First name to replace.</param>
    /// <param name="lastName">Last name to replace.</param>
    /// <param name="email">Email to replace.</param>
    /// <returns></returns>
    public static Result<UpdateUserCommand> Create(string uid, string? firstName, string? lastName, string? email)
    {
        // ! Validate the user's input
        var validationResult = Validate(uid, firstName, lastName, email);

        // ? Were there any errors?
        if (validationResult.IsFailure)
            return Result<UpdateUserCommand>.Failure(validationResult.Errors.ToArray());

        // * Return the newly created command
        return Result<UpdateUserCommand>.Success(new UpdateUserCommand(new Guid(uid), firstName, lastName, email));
    }

    /// <summary>
    /// Validates if the changes are allowed.
    /// </summary>
    /// <param name="uid">Uid to be checked.</param>
    /// <param name="firstName">First name to be checked.</param>
    /// <param name="lastName">Last name to be checked.</param>
    /// <param name="email">Email to be checked.</param>
    /// <returns></returns>
    private static Result Validate(string uid, string? firstName, string? lastName, string? email)
    {
        // ! Try to parse the UID
        if (!Guid.TryParse(uid, out var parsedUid))
            return Result.Failure(new FailedOperationException("The given UID could not be parsed into a GUID"));

        // * Initialize a collection to store errors
        // This allows the user to fix multiple errors at once
        List<Exception> errors = [];

        // ! Validate the first name
        if (!string.IsNullOrEmpty(firstName))
        {
            var firstNameResult = UserValidator.ValidateFirstName(firstName);

            // ? Was the first name valid?
            if (firstNameResult.IsFailure)
                errors.AddRange(firstNameResult.Errors);
        }

        // ! Validate the last name
        if (!string.IsNullOrEmpty(lastName))
        {
            var lastNameResult = UserValidator.ValidateLastName(lastName);

            // ? Was the last name valid?
            if (lastNameResult.IsFailure)
                errors.AddRange(lastNameResult.Errors);
        }

        // ! Validate the email
        if (!string.IsNullOrEmpty(email))
        {
            var emailResult = UserValidator.ValidateEmail(email);

            // ? Was the email valid?
            if (emailResult.IsFailure)
                errors.AddRange(emailResult.Errors);
        }

        // * Return the errors if any, otherwise return success.
        return errors.Count > 0 ? Result.Failure(errors.ToArray()) : Result.Success();

    }



}
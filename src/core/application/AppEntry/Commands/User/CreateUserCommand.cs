using System.Windows.Input;
using domain.models.user;
using OperationResult;

namespace application.AppEntry.Commands.user;

/// <summary>
/// The command to be used for creating new users in the system.
/// </summary>
public class CreateUserCommand
{
    /// <summary>
    /// The User's UID
    /// </summary>
    public Guid Uid { get; set; }

    /// <summary>
    /// The User's first name.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// The User's last name.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// The User's email.
    /// </summary>
    public string Email { get; }

    private CreateUserCommand(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    /// <summary>
    /// Creates the command to create a new user.
    /// </summary>
    /// <param name="firstName">First name to use.</param>
    /// <param name="lastName">Last name to use.</param>
    /// <param name="email">Email to use.</param>
    /// <returns>Returns either a Failure Result with a collection of errors to be fixed or the Command to proceed.</returns>
    public static Result<CreateUserCommand> Create(string firstName, string lastName, string email)
    {
        // ! Validate the user's input
        var validationResult = Validate(firstName, lastName, email);

        // ? Were there any validation errors?
        if (validationResult.IsFailure)
            return Result<CreateUserCommand>.Failure(validationResult.Errors.ToArray());

        // * Return the newly created command.
        return new CreateUserCommand(firstName, lastName, email);
    }

    /// <summary>
    /// Validates the user's input.
    /// </summary>
    /// <param name="firstName">First name to be checked.</param>
    /// <param name="lastName">Last name to be checked.</param>
    /// <param name="email">Email to be checked.</param>
    /// <returns>Returns either a Failure Result with a collection of errors to be fixed or a Success Result.</returns>
    private static Result Validate(string firstName, string lastName, string email)
    {
        // * Initialize a collection to store errors
        // This allows the user to fix multiple errors at once
        List<Exception> errors = [];

        // ! Validate the first name
        var firstNameResult = UserValidator.ValidateFirstName(firstName);

        // ? Was the first name valid?
        if (firstNameResult.IsFailure)
            errors.AddRange(firstNameResult.Errors);

        // ! Validate the last name
        var lastNameResult = UserValidator.ValidateLastName(lastName);

        // ? Was the last name valid?
        if (lastNameResult.IsFailure)
            errors.AddRange(lastNameResult.Errors);

        // ! Validate the email
        var emailResult = UserValidator.ValidateEmail(email);

        // ? Was the email valid?
        if (emailResult.IsFailure)
            errors.AddRange(emailResult.Errors);

        // * Return the errors if any, otherwise return success.
        return errors.Count > 0 ? Result.Failure(errors.ToArray()) : Result.Success();
    }

}
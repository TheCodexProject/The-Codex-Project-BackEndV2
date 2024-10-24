using domain.exceptions.common;
using OperationResult;
using static System.String;

namespace application.AppEntry.Commands.user;

/// <summary>
/// The command to be used for getting a specific user from the system.
/// </summary>
public class GetUserCommand
{
    /// <summary>
    /// The User's UID
    /// </summary>
    public Guid Uid { get; set; }

    /// <summary>
    /// The User's first name.
    /// </summary>
    public string? FirstName { get; set; } = Empty;

    /// <summary>
    /// The User's last name.
    /// </summary>
    public string? LastName { get; set; } = Empty;

    /// <summary>
    /// The User's email.
    /// </summary>
    public string? Email { get; set; } = Empty;

    private GetUserCommand(Guid uid)
    {
        Uid = uid;
    }

    /// <summary>
    /// Creates the command to get a user.
    /// </summary>
    /// <param name="uid">Uid to look for.</param>
    /// <returns></returns>
    public static Result<GetUserCommand> Create(string uid)
    {
        // ! Validate the user's input
        var validationResult = Validate(uid);

        // ? Were there any validation errors?
        if (validationResult.IsFailure)
            return Result<GetUserCommand>.Failure(validationResult.Errors.ToArray());

        // * Return the newly created command.
        return new GetUserCommand(validationResult);
    }

    /// <summary>
    /// Validates the user's input.
    /// </summary>
    /// <param name="uid">Uid to be checked.</param>
    /// <returns></returns>
    private static Result<Guid> Validate(string uid)
    {
        // ! Try to parse the UID
        if (!Guid.TryParse(uid, out var parsedUid))
            return Result<Guid>.Failure(new FailedOperationException("The given UID could not be parsed into a GUID"));

        // * Return the parsed UID
        return Result<Guid>.Success(parsedUid);
    }

}
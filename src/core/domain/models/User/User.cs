using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.interfaces;
using OperationResult;

namespace domain.models.user;

/// <summary>
/// A class that represents a user within the system.
/// </summary>
public class User
{
    /// <summary>
    /// The unique identifier of the user.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    /// <summary>
    /// The last name of the user.
    /// </summary>
    [MaxLength(50)]
    [MinLength(2)]
    [Required]
    public string? FirstName { get;  private set; }

    /// <summary>
    /// The last name of the user.
    /// </summary>
    [MaxLength(60)]
    [MinLength(2)]
    [Required]
    public string? LastName { get; private set; }

    /// <summary>
    /// The email of the user.
    /// </summary>
    [MaxLength(60)]
    [Required]
    public string? Email { get; private set; }

    /// <summary>
    /// Private constructor for the <see cref="User"/> class.
    /// </summary>
    private User()
    {
        Uid = Guid.NewGuid();
    }

    // TODO: Add a encrypted password property here, when working on authentication.

    /// <summary>
    /// Constructs a new instance of <see cref="User"/>.
    /// </summary>
    /// <returns></returns>
    public static User Create()
    {
        return new User();
    }

    // TODO: Add methods to update the user's properties. (e.g. UpdateFirstName, UpdateLastName, UpdateEmail)

    public Result UpdateFirstName(string firstName)
    {
        // ! Validate the first name.
        var result = UserValidator.ValidateFirstName(firstName);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the first name.
        FirstName = firstName;

        return Result.Success();
    }

    public Result UpdateLastName(string lastName)
    {
        // ! Validate the last name.
        var result = UserValidator.ValidateLastName(lastName);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the last name.
        LastName = lastName;

        return Result.Success();
    }

    public Result UpdateEmail(string email)
    {
        // ! Validate the email.
        var result = UserValidator.ValidateEmail(email);

        // ? Is the result a failure?
        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        // * Update the email.
        Email = email;

        return Result.Success();
    }
}



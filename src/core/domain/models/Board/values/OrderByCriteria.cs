using OperationResult;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.models.board.values;

public class OrderByCriteria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    [ForeignKey("BoardUid")]
    public Guid BoardUid { get; private set; }

    [Required]
    public string PropertyName { get; set; }

    [Required]
    public bool IsAscending { get; set; }

    private OrderByCriteria()
    {
        Uid = Guid.NewGuid();
    }

    public static OrderByCriteria Create()
    {

        return new OrderByCriteria();
    }

    /// <summary>
    /// Updates the property name of the OrderByCriteria.
    /// </summary>
    /// <param name="propertyName">The new property name to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was successful or a failure.</returns>
    public Result UpdatePropertyName(string propertyName)
    {
        // ? Validate the input.
        var result = OrderByCriteriaValidator.ValidatePropertyName(propertyName);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else, update the property name.
        PropertyName = propertyName;

        // * Return success.
        return Result.Success();
    }

    /// <summary>
    /// Updates the IsAscending value of the OrderByCriteria.
    /// </summary>
    /// <param name="isAscending">The new value to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was successful or a failure.</returns>
    public Result UpdateIsAscending(bool isAscending)
    {
        // ? Validate the input.
        var result = OrderByCriteriaValidator.ValidateIsAscending(isAscending);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else, update the IsAscending value.
        IsAscending = isAscending;

        // * Return success.
        return Result.Success();
    }
}

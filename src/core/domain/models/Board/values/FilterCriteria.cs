using OperationResult;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.models.board.values;

public class FilterCriteria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    [ForeignKey("BoardUid")]
    public Guid BoardUid { get; private set; }

    [Required]
    public string? PropertyName { get; set; }

    [Required]
    public string? Operator { get; set; } // e.g., "Equals", "Contains", etc.

    [Required]
    public string? Value { get; set; }

    private FilterCriteria() { 
        Uid = Guid.NewGuid();
    }

    public static FilterCriteria Create()
    {
        return new FilterCriteria();
    }

    /// <summary>
    /// Updates the property name of the FilterCriteria.
    /// </summary>
    /// <param name="propertyName">The new property name to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was successful or a failure.</returns>
    public Result UpdatePropertyName(string propertyName)
    {
        // ? Validate the input.
        var result = FilterCriteriaValidator.ValidatePropertyName(propertyName);

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
    /// Updates the operator of the FilterCriteria.
    /// </summary>
    /// <param name="operator">The new operator to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was successful or a failure.</returns>
    public Result UpdateOperator(string @operator)
    {
        // ? Validate the input.
        var result = FilterCriteriaValidator.ValidateOperator(@operator);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else, update the operator.
        Operator = @operator;

        // * Return success.
        return Result.Success();
    }

    /// <summary>
    /// Updates the value of the FilterCriteria.
    /// </summary>
    /// <param name="value">The new value to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was successful or a failure.</returns>
    public Result UpdateValue(string value)
    {
        // ? Validate the input.
        var result = FilterCriteriaValidator.ValidateValue(value);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else, update the value.
        Value = value;

        // * Return success.
        return Result.Success();
    }
}


using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OperationResult;

namespace domain.models.board.values;

public static class FilterCriteriaValidator
{
    /// <summary>
    /// Helper method to validate the PropertyName of FilterCriteria.
    /// </summary>
    /// <param name="propertyName">The property name to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the property name is valid or not.</returns>
    public static Result ValidatePropertyName(string propertyName)
    {
        // ? Is the property name null or empty?
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            return Result.Failure(new ArgumentNullException(nameof(propertyName), "Property name cannot be null or empty."));
        }

        // ? Is the property name too long?
        if (propertyName.Length > 75)
        {
            return Result.Failure(new ArgumentException("Property name cannot exceed 75 characters."));
        }

        // Additional checks can be added here as needed

        return Result.Success();
    }

    /// <summary>
    /// Helper method to validate the Operator of FilterCriteria.
    /// </summary>
    /// <param name="operator">The operator to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the operator is valid or not.</returns>
    public static Result ValidateOperator(string @operator)
    {
        // ? Is the operator null or empty?
        if (string.IsNullOrWhiteSpace(@operator))
        {
            return Result.Failure(new ArgumentNullException(nameof(@operator), "Operator cannot be null or empty."));
        }

        // ? Is the operator supported?
        var validOperators = new[] { "Equals", "Contains", "GreaterThan", "LessThan" };
        if (!validOperators.Contains(@operator))
        {
            return Result.Failure(new ArgumentException($"The provided operator '{@operator}' is not supported."));
        }

        return Result.Success();
    }

    /// <summary>
    /// Helper method to validate the Value of FilterCriteria.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the value is valid or not.</returns>
    public static Result ValidateValue(string value)
    {
        // ? Is the value null or empty?
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure(new ArgumentNullException(nameof(value), "Value cannot be null or empty."));
        }

        // ? Is the property name too long?
        if (value.Length > 75)
        {
            return Result.Failure(new ArgumentException("Property name cannot exceed 75 characters."));
        }

        return Result.Success();
    }
}

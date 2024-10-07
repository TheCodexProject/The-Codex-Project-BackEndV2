

using domain.exceptions.common;
using domain.exceptions.models.board.filterCriteria;
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
            return Result.Failure(new NotFoundException("The property orderBy is invalid. Property cannot be empty."));
        }

        // ? Is the property name too long?
        if (propertyName.Length > 75)
        {
            return Result.Failure(new FilterCriteriaPropertyNameTooLongException());
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
            return Result.Failure(new NotFoundException("The provided operator is invalid. Operator cannot be empty."));
        }

        // ? Is the operator supported?
        var validOperators = new[] { "Equals", "Contains", "GreaterThan", "LessThan" };
        if (!validOperators.Contains(@operator))
        {
            return Result.Failure(new FilterCriteriaOperaterNotSupportedException());
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
            return Result.Failure(new NotFoundException("The provided value is invalid. Value cannot be empty."));
        }

        // ? Is the property name too long?
        if (value.Length > 75)
        {
            return Result.Failure(new FilterCriteriaValueNameTooLongException());
        }

        return Result.Success();
    }
}

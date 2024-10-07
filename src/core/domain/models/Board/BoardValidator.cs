using domain.exceptions.common;
using domain.exceptions.models.board.boardTitle;
using domain.exceptions.models.Workspace;
using domain.models.board.values;
using OperationResult;

namespace domain.models.board;

public class BoardValidator
{
    /// <summary>
    /// Helper method to validate the title of the Board.
    /// </summary>
    /// <param name="title">Title to be validated.</param>
    /// <returns>A <see cref="Result"/> indicating if the title is valid or not.</returns>
    public static Result<string> ValidateTitle(string title)
    {
        var errors = new List<Exception>();

        // ? Is the title null, empty, or whitespace?
        if (string.IsNullOrWhiteSpace(title))
        {
            errors.Add(new BoardTitleEmptyException());
            return Result<string>.Failure(errors.ToArray());
        }

        // ? Is the title too short or too long?
        switch (title)
        {
            case { Length: < 3 }:
                errors.Add(new BoardTitleTooShortException());
                break;
            case { Length: > 75 }:
                errors.Add(new BoardTitleTooLongException());
                break;
        }

        // * If there are any errors, return failure; otherwise, return success.
        return errors.Any() ? Result<string>.Failure(errors.ToArray()) : Result<string>.Success(title);
    }

    /// <summary>
    /// Helper method to validate adding a filter criteria to the Board.
    /// </summary>
    /// <param name="filterCriteria">Filter criteria to validate.</param>
    /// <param name="filterCriterias">List of filter criteria to validate against.</param>
    /// <returns>A <see cref="Result"/> indicating if the filter criteria is valid or not.</returns>
    public static Result ValidateAddFilterCriteria(FilterCriteria filterCriteria, List<FilterCriteria> filterCriterias)
    {
        // ? Is the filter criteria null?
        if (filterCriteria == null)
        {
            return Result.Failure(new ArgumentNullException(nameof(filterCriteria), "Filter criteria cannot be null."));
        }

        // ? Is the filter criteria already in the list?
        if (filterCriterias.Any(fc => fc.Uid == filterCriteria.Uid))
        {
            return Result.Failure(new AlreadyExistsException("The provided filter criteria already exists in the list."));
        }

        return Result.Success();
    }

    /// <summary>
    /// Helper method to validate removing a filter criteria from the Board.
    /// </summary>
    /// <param name="filterCriteria">Filter criteria to validate.</param>
    /// <param name="filterCriterias">List of filter criteria to validate against.</param>
    /// <returns>A <see cref="Result"/> indicating if the filter criteria is valid or not.</returns>
    public static Result ValidateRemoveFilterCriteria(FilterCriteria filterCriteria, List<FilterCriteria> filterCriterias)
    {
        // ? Is the filter criteria null?
        if (filterCriteria == null)
        {
            return Result.Failure(new ArgumentNullException(nameof(filterCriteria), "Filter criteria cannot be null."));
        }

        // ? Does the filter criteria exist in the list?
        if (!filterCriterias.Any(fc => fc.Uid == filterCriteria.Uid))
        {
            return Result.Failure(new NotFoundException("The provided filter criteria does not exist in the list."));
        }

        return Result.Success();
    }

    /// <summary>
    /// Helper method to validate adding an order by criteria to the Board.
    /// </summary>
    /// <param name="orderByCriteria">Order by criteria to validate.</param>
    /// <param name="orderByCriterias">List of order by criteria to validate against.</param>
    /// <returns>A <see cref="Result"/> indicating if the order by criteria is valid or not.</returns>
    public static Result ValidateAddOrderByCriterias(OrderByCriteria orderByCriteria, List<OrderByCriteria> orderByCriterias)
    {
        // ? Is the order by criteria null?
        if (orderByCriteria == null)
        {
            return Result.Failure(new ArgumentNullException(nameof(orderByCriteria), "Order by criteria cannot be null."));
        }

        // ? Is the order by criteria already in the list?
        if (orderByCriterias.Any(ob => ob.Uid == orderByCriteria.Uid))
        {
            return Result.Failure(new AlreadyExistsException("The provided order by criteria already exists in the list."));
        }

        return Result.Success();
    }

    /// <summary>
    /// Helper method to validate removing an order by criteria from the Board.
    /// </summary>
    /// <param name="orderByCriteria">Order by criteria to validate.</param>
    /// <param name="orderByCriterias">List of order by criteria to validate against.</param>
    /// <returns>A <see cref="Result"/> indicating if the order by criteria is valid or not.</returns>
    public static Result ValidateRemoveOrderByCriterias(OrderByCriteria orderByCriteria, List<OrderByCriteria> orderByCriterias)
    {
        // ? Is the order by criteria null?
        if (orderByCriteria == null)
        {
            return Result.Failure(new ArgumentNullException(nameof(orderByCriteria), "Order by criteria cannot be null."));
        }

        // ? Does the order by criteria exist in the list?
        if (!orderByCriterias.Any(ob => ob.Uid == orderByCriteria.Uid))
        {
            return Result.Failure(new NotFoundException("The provided order by criteria does not exist in the list."));
        }

        return Result.Success();
    }
}

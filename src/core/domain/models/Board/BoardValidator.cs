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
        // Check if the title is null, empty, or whitespace.
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result<string>.Failure(new BoardTitleEmptyException());
        }

        // Check if the title is too short.
        if (title.Length < 3)
        {
            return Result<string>.Failure(new BoardTitleTooShortException());
        }

        // Check if the title is too long.
        if (title.Length > 75)
        {
            return Result<string>.Failure(new BoardTitleTooLongException());
        }

        // If all validations pass, return success.
        return Result<string>.Success(title);
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
            return Result.Failure(new NotFoundException("The provided filter is invalid. Filter cannot be empty."));
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
            return Result.Failure(new NotFoundException("The provided filter is invalid. Filter cannot be empty."));
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
            return Result.Failure(new NotFoundException("The provided orderBy is invalid. OrderBy cannot be empty."));
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
            return Result.Failure(new NotFoundException("The provided orderBy is invalid. OrderBy cannot be empty."));
        }

        // ? Does the order by criteria exist in the list?
        if (!orderByCriterias.Any(ob => ob.Uid == orderByCriteria.Uid))
        {
            return Result.Failure(new NotFoundException("The provided order by criteria does not exist in the list."));
        }

        return Result.Success();
    }
}

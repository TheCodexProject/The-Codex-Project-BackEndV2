

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.models.board.values;
using domain.models.board;
using OperationResult;

namespace domain.models.board;

public class Board
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Uid { get; private set; }

    [ForeignKey("Project")]
    public Guid ProjectUid { get; private set; }

    [MaxLength(75)]
    [MinLength(3)]
    [Required]
    public string? Title { get; private set; }

    public List<FilterCriteria> FilterCriterias { get; private set; } = [];

    public List<OrderByCriteria> OrderByCriterias { get; private set; } = [];

    private Board()
    {
        Uid = Guid.NewGuid();
    }

    public static Board Create()
    {
        // ! No validation needed here
        // As the Board is to be modified through the provided methods.
        return new Board();
    }

    /// <summary>
    /// Updates the title of the Workspace.
    /// </summary>
    /// <param name="title">The new title to be set.</param>
    /// <returns>A <see cref="Result"/> indicating if the operation was success or a failure.</returns>
    public Result UpdateTitle(string title)
    {
        // ? Validate the input.
        var result = BoardValidator.ValidateTitle(title);

        // ? Was it a failure?
        if (result.IsFailure)
        {
            // ! Return the errors.
            return Result.Failure(result.Errors.ToArray());
        }

        // * Else we want to update the title.
        Title = result;

        // * Return a success.
        return Result.Success();
    }

    /// <summary>
    /// Adds a contact to the list of contacts.
    /// </summary>
    /// <param name="contact">Contact to be added.</param>
    /// <returns></returns>
    public Result AddFilterCriterias(FilterCriteria filterCriteria)
    {
        var result = BoardValidator.ValidateAddFilterCriteria(filterCriteria, FilterCriterias);

        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        FilterCriterias.Add(filterCriteria);

        return Result.Success();
    }

    /// <summary>
    /// Removes a contact from the list of contacts.
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    public Result RemoveFilterCriterias(FilterCriteria filterCriteria)
    {
        var result = BoardValidator.ValidateRemoveFilterCriteria(filterCriteria, FilterCriterias);

        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        FilterCriterias.Remove(filterCriteria);

        return Result.Success();
    }

    /// <summary>
    /// Adds a contact to the list of contacts.
    /// </summary>
    /// <param name="contact">Contact to be added.</param>
    /// <returns></returns>
    public Result AddOrderByCriterias(OrderByCriteria orderByCriteria)
    {
        var result = BoardValidator.ValidateAddOrderByCriterias(orderByCriteria, OrderByCriterias);

        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        OrderByCriterias.Add(orderByCriteria);

        return Result.Success();
    }

    /// <summary>
    /// Removes a contact from the list of contacts.
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    public Result RemoveOrderByCriterias(OrderByCriteria orderByCriteria)
    {
        var result = BoardValidator.ValidateRemoveOrderByCriterias(orderByCriteria, OrderByCriterias);

        if (result.IsFailure)
        {
            return Result.Failure(result.Errors.ToArray());
        }

        OrderByCriterias.Remove(orderByCriteria);

        return Result.Success();
    }
}
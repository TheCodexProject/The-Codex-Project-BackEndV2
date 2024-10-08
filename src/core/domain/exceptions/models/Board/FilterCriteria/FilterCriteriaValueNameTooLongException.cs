
namespace domain.exceptions.models.board.filterCriteria;

public class FilterCriteriaValueNameTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public FilterCriteriaValueNameTooLongException() : base("Value cannot be more then 75 characters") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public FilterCriteriaValueNameTooLongException(string message) : base(message) { }
}

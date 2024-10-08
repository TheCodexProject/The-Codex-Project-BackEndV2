
namespace domain.exceptions.models.board.filterCriteria;

public class FilterCriteriaPropertyNameTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public FilterCriteriaPropertyNameTooLongException() : base("Title cannot be more then 75 characters") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public FilterCriteriaPropertyNameTooLongException(string message) : base(message) { }
}

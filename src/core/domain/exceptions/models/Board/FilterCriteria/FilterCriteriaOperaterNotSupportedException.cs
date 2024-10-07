
namespace domain.exceptions.models.board.filterCriteria;

public class FilterCriteriaOperaterNotSupportedException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public FilterCriteriaOperaterNotSupportedException() : base("The filter criteria operator is not supported.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public FilterCriteriaOperaterNotSupportedException(string message) : base(message) { }
}


namespace domain.exceptions.models.board.orderbycriteria;

public class OrderByCriteriaPropertyNameTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public OrderByCriteriaPropertyNameTooLongException() : base("Value cannot be more then 75 characters") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public OrderByCriteriaPropertyNameTooLongException(string message) : base(message) { }
}

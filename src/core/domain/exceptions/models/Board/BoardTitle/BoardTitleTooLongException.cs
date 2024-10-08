namespace domain.exceptions.models.board.boardTitle;

/// <summary>
/// Exception for when a Board is created with a title that are too long.
/// </summary>
public class BoardTitleTooLongException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public BoardTitleTooLongException() : base("Title cannot be more then 75 characters") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public BoardTitleTooLongException(string message) : base(message) { }
}

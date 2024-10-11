namespace domain.exceptions.models.board.boardtitle;

/// <summary>
/// Exception for when a Board is created without a title.
/// </summary>
public class BoardTitleEmptyException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public BoardTitleEmptyException() : base("Title cannot be empty, it must be between 3 and 75 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public BoardTitleEmptyException(string message) : base(message) { }
}

namespace domain.exceptions.models.board.boardtitle;

/// <summary>
/// Exception for when a Board is created with a too short title
/// </summary>
public class BoardTitleTooShortException : Exception
{
    /// <summary>
    /// The default message.
    /// </summary>
    public BoardTitleTooShortException() : base("Title is too short, it must be more then 3 characters.") { }

    /// <summary>
    /// Used for custom messages.
    /// </summary>
    /// <param name="message">Customized message.</param>
    public BoardTitleTooShortException(string message) : base(message) { }
}

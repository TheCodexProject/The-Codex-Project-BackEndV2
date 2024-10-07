using OperationResult;

namespace domain.interfaces;

/// <summary>
/// A generic builder interface for building objects.
/// </summary>
/// <typeparam name="T">Type that the builder can build. </typeparam>
public interface IBuilder<T>
{
    /// <summary>
    /// Builds an object of type T.
    /// </summary>
    /// <returns>A result showing if the operation succeed or failed.</returns>
    Result<T> Build();

    /// <summary>
    /// Builds a default object of type T.
    /// </summary>
    /// <returns>A result showing if the operation succeed or failed.</returns>
    Result<T> MakeDefault();
}
namespace ChatAIze.Abstractions.Databases.Exceptions;

/// <summary>
/// Base exception type for errors raised by <see cref="ChatAIze.Abstractions.Databases.IDatabaseManager"/> implementations.
/// </summary>
/// <remarks>
/// Hosts throw these exceptions to indicate validation and persistence errors when managing custom databases.
/// </remarks>
public class DatabaseException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseException"/> class.
    /// </summary>
    public DatabaseException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public DatabaseException(string? message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public DatabaseException(string? message, Exception? innerException) : base(message, innerException) { }
}

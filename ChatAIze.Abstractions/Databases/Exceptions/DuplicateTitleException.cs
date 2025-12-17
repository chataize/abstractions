namespace ChatAIze.Abstractions.Databases.Exceptions;

/// <summary>
/// Thrown when attempting to create or rename a database (or item) to a title that already exists.
/// </summary>
/// <remarks>
/// Titles are typically compared using a normalized form (see <c>NormalizedTitle</c> on database/item types), so
/// <c>"My Database"</c> and <c>"my_database"</c> may be considered duplicates by a host implementation.
/// </remarks>
public class DuplicateTitleException : DatabaseException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DuplicateTitleException"/> class.
    /// </summary>
    public DuplicateTitleException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DuplicateTitleException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public DuplicateTitleException(string? message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DuplicateTitleException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public DuplicateTitleException(string? message, Exception? innerException) : base(message, innerException) { }
}

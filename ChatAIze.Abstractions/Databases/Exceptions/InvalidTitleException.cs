namespace ChatAIze.Abstractions.Databases.Exceptions;

/// <summary>
/// Thrown when a database or item title is invalid for the host implementation.
/// </summary>
/// <remarks>
/// Hosts may impose length/character constraints and normalize titles for indexing.
/// </remarks>
public class InvalidTitleException : DatabaseException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidTitleException"/> class.
    /// </summary>
    public InvalidTitleException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidTitleException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidTitleException(string? message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidTitleException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public InvalidTitleException(string? message, Exception? innerException) : base(message, innerException) { }
}

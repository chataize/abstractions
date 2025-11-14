namespace ChatAIze.Abstractions.Databases.Exceptions;

/// <summary>
/// Represents an error that occurs when a database property is invalid or cannot be processed.
/// </summary>
public class PropertyException : DatabaseException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyException"/> class.
    /// </summary>
    public PropertyException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public PropertyException(string? message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public PropertyException(string? message, Exception? innerException) : base(message, innerException) { }
}

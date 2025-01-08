namespace ChatAIze.Abstractions.Databases.Exceptions;

public class PropertyException : DatabaseException
{
    public PropertyException() { }

    public PropertyException(string? message) : base(message) { }

    public PropertyException(string? message, Exception? innerException) : base(message, innerException) { }
}

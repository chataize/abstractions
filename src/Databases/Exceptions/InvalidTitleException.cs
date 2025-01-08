namespace ChatAIze.Abstractions.Databases.Exceptions;

public class InvalidTitleException : DatabaseException
{
    public InvalidTitleException() { }

    public InvalidTitleException(string? message) : base(message) { }

    public InvalidTitleException(string? message, Exception? innerException) : base(message, innerException) { }
}

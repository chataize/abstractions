namespace ChatAIze.Abstractions.Databases.Exceptions;

public class DuplicateTitleException : DatabaseException
{
    public DuplicateTitleException() { }

    public DuplicateTitleException(string? message) : base(message) { }

    public DuplicateTitleException(string? message, Exception? innerException) : base(message, innerException) { }
}

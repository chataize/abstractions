namespace ChatAIze.Abstractions.Databases;

public interface IDatabase
{
    public Guid Id { get; }

    public string Title { get; }

    public string? Description { get; }

    public DateTimeOffset CreationTime { get; }

    public DateTimeOffset LastUpdateTime { get; }
}

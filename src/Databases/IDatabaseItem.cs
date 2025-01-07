namespace ChatAIze.Abstractions.Databases;

public interface IDatabaseItem
{
    public Guid Id { get; }

    public string Title { get; }

    public string? Description { get; }

    public IReadOnlyDictionary<string, string> Properties { get; }

    public DateTimeOffset CreationTime { get; }

    public DateTimeOffset LastUpdateTime { get; }
}
